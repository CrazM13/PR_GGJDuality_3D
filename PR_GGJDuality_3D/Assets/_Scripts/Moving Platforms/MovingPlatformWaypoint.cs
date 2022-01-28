using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovingPlatformWaypoint {

	[SerializeField] private Vector3 position;
	[SerializeField] private Quaternion rotation;

	public Vector3 Position { get; private set; }
	public Quaternion Rotation { get; private set; }

	public Vector3 Forward => Rotation * Vector3.forward;
	public Vector3 Right => Rotation * Vector3.right;

	public MovingPlatformWaypoint() {
		Position = Vector3.zero;
		Rotation = Quaternion.identity;
	}

	public MovingPlatformWaypoint(Vector3 position) {
		Position = position;
		Rotation = Quaternion.identity;
	}

	public MovingPlatformWaypoint(Vector3 position, Quaternion rotation) {
		Position = position;
		Rotation = rotation;
	}

	public void SetPosition(Vector3 position) {
		Position = position;
	}

	public void SetRotation(Quaternion rotation) {
		Rotation = rotation;
	}

}
