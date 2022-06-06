using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Rigidbody2D rb { get; private set; }

    public Vector2 direction { get; private set; }

    public float speed = 30f;

    public float maxBounceAngle = 75f;

    public GameObject[] bricks;

    private void Awake() {
        this.rb = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        if(Input.GetKey(KeyCode.A)) this.direction = Vector2.left;
        else if(Input.GetKey(KeyCode.D)) this.direction = Vector2.right;
        else this.direction = Vector2.zero;
    }

    private void FixedUpdate(){
        if(this.direction != Vector2.zero){
            this.rb.AddForce(this.direction * this.speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if(ball != null){
            Vector3 paddlePosition = this.transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = paddlePosition.x - contactPoint.x;
            float width = collision.otherCollider.bounds.size.x;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.rb.velocity);
            float bounceAngle = (offset / width) * this.maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -this.maxBounceAngle, this.maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.rb.velocity = rotation * Vector2.up * ball.rb.velocity.magnitude;
        }
    }
}
