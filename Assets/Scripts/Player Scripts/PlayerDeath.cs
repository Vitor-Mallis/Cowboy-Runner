using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour {

	public delegate void IsDead();
	public static event IsDead isDead;

	void Die() {
		if (isDead != null) {
			isDead ();
		}
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.name == "Collector") {
			Die ();
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Zombie") {
			Die ();
		}
	}
}
