using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	[SerializeField] private float movementSpeed;

	[Header("Path")]
	[SerializeField] private MovingPlatformWaypoint[] waypoints;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}

#if UNITY_EDITOR
	private void OnDrawGizmosSelected() {
		
	}
#endif


}
