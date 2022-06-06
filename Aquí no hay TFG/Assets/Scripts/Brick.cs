using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public SpriteRenderer sr { get; private set; }

    public Sprite[] states;

    public int health { get; private set; }

    public bool unbreakable;

    private void Awake() {
        this.sr = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        if(!this.unbreakable){
            this.health = this.states.Length;
            this.sr.sprite = this.states[this.health - 1];
        }
    }

    private void Hit(){
        if(this.unbreakable) return;
        this.health--;
        if(this.health <= 0) Destroy(this.gameObject)/*this.gameObject.SetActive(false)*/;
        else this.sr.sprite = this.states[this.health - 1];
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "Dotball") Hit();
    }
}
