using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovingPlatformWaypoint {

	[SerializeField] private Vector3 position;

	public Vector3 Position => position;

	public MovingPlatformWaypoint() {
		this.position = Vector3.zero;
	}

	public MovingPlatformWaypoint(Vector3 position) {
		this.position = position;
	}

	public void SetPosition(Vector3 position) {
		this.position = position;
	}

}
