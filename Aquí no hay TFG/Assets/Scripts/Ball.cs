using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb { get; private set; }

    public float speed = 200f;

    private void Awake() {
        this.rb = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        Invoke(nameof(SetRandomTrajectory), 1f);
    }

    private void SetRandomTrajectory(){
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        this.rb.AddForce(force.normalized * this.speed);
    }
}