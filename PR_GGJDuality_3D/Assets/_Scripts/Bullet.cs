using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private void OnCollisionEnter(Collision collision) {
		PlayerManager player = collision.collider.GetComponent<PlayerManager>();
		if (!player) return;

		player.Kill();
	}

}
