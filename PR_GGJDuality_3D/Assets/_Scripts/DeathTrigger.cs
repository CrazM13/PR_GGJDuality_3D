using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour {

	private void OnTriggerEnter(Collider other) {
		PlayerMovement player = other.GetComponent<PlayerMovement>();
		if (player) player.Die();
	}

}
