using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour {

    Rigidbody2D rigidBody;
    Animator animator;

    void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Obstacle") {
            animator.Play("Idle");
        }
        else if(collision.gameObject.name == "Ground") {
            animator.Play("Running");
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        animator.Play("Jumping");
    }
}
