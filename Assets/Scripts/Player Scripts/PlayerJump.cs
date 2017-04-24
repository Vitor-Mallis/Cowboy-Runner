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

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.name == "Ground" || collision.gameObject.tag == "Obstacle") {
				canJump = true;
		}
	}
}
