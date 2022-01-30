using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour {

	private void OnTriggerEnter(Collider other) {
		PlayerManager player = other.GetComponent<PlayerManager>();
		if (player) player.Kill();
	}

}
