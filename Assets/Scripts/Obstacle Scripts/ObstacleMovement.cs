using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour {

    float speed = -1.5f;

    Rigidbody2D rigidBody;

    void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

	void FixedUpdate () {
		if(gameObject.activeInHierarchy) {
            rigidBody.velocity = new Vector3(speed, 0, 0);
        }
	}
}
