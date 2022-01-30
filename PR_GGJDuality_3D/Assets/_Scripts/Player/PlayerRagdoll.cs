using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRagdoll : MonoBehaviour {

	[SerializeField] private Transform[] ragdollComponents;

	private Vector3[] savedPositions;
	private Quaternion[] savedRotations;

	public void StartRagdoll() {

		foreach (Transform ragdollPart in ragdollComponents) {
			Rigidbody rb = ragdollPart.GetComponent<Rigidbody>();
			rb.isKinematic = false;
			rb.detectCollisions = true;
			rb.AddExplosionForce(5000f, Random.insideUnitSphere + ragdollPart.position, 1);

			Collider c = ragdollPart.GetComponent<Collider>();
			c.enabled = true;
		}
	}

	public void StopRagdoll() {
		foreach (Transform ragdollPart in ragdollComponents) {
			Rigidbody rb = ragdollPart.GetComponent<Rigidbody>();
			rb.isKinematic = true;
			rb.detectCollisions = false;

			Collider c = ragdollPart.GetComponent<Collider>();
			c.enabled = false;
		}
	}

	public void Save() {

		savedPositions = new Vector3[ragdollComponents.Length];
		savedRotations = new Quaternion[ragdollComponents.Length];

		for (int i = 0; i < ragdollComponents.Length; i++) {
			savedPositions[i] = ragdollComponents[i].position;
			savedRotations[i] = ragdollComponents[i].rotation;
		}
	}

	public void Restore() {
		if (savedPositions.Length != ragdollComponents.Length) return;

		for (int i = 0; i < ragdollComponents.Length; i++) {
			ragdollComponents[i].position = savedPositions[i];
			ragdollComponents[i].rotation = savedRotations[i];
		}
	}


}
