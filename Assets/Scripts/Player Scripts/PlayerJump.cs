using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    bool canJump;
    float jumpSpeed = 12f;
    float forwardSpeed = 1f;

    Rigidbody2D rigidBody;

    [SerializeField]
    AudioClip jumpClip;

    void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (canJump == false) {
            if (rigidBody.velocity.y == 0) {
                canJump = true;
            }
        }
    }

	public void Jump() {
        if (canJump) {
            canJump = false;

            AudioSource.PlayClipAtPoint(jumpClip, transform.position);

            if (transform.position.x < 0) {
                forwardSpeed = 1f;
            }
            else {
                forwardSpeed = 0f;
            }

            rigidBody.velocity = new Vector3(forwardSpeed, jumpSpeed);
        }
    }
}
