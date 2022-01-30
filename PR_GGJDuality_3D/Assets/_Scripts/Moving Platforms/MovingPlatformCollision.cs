using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingPlatformCollision : MonoBehaviour {

	private Vector3 lastPos;

	[SerializeField] private UnityEvent onPlayerColliding;

	private void OnCollisionEnter(Collision collision) {
		PlayerMovement player = collision.collider.GetComponent<PlayerMovement>();
		if (!player) return;

		for (int i = 0; i < collision.contactCount; i++) {
			Vector3 normal = collision.GetContact(i).normal;

			if (Vector3.Angle(normal, -transform.up) < 30) {
				lastPos = transform.position;
			}
		}
	}

	private void OnCollisionStay(Collision collision) {
		PlayerMovement player = collision.collider.GetComponent<PlayerMovement>();
		if (!player) return;

		for (int i = 0; i < collision.contactCount; i++) {
			Vector3 normal = collision.GetContact(i).normal;

			if (Vector3.Angle(normal, -transform.up) < 30) {
				Vector3 newPos = transform.position;

				Vector3 movement = newPos - lastPos;
				player.ForceMovePlayer(movement);

				lastPos = newPos;
				onPlayerColliding?.Invoke();
			}
		}
	}

}
