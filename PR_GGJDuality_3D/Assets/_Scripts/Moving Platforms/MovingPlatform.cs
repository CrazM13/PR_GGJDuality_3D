using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	[Header("Platform")]
	[SerializeField] private Transform platform;
	[SerializeField, Tooltip("Meters/Second")] private float movementSpeed;

	[Header("Path")]
	[SerializeField] private MovingPlatformWaypoint[] waypoints;

	private MovingPlatformWaypoint[] fullPath;

	private float distanceSpeedModifier = 1;

	private float timeFromLastWaypoint = 0;
	private int currentWaypointIndex = 0;
	private int NextWaypointIndex => (currentWaypointIndex + 1) % fullPath.Length;

	private MovingPlatformWaypoint CurrentWaypoint => fullPath[currentWaypointIndex];
	private MovingPlatformWaypoint NextWaypoint => fullPath[NextWaypointIndex];

	// Start is called before the first frame update
	void Start() {
		ConstructFullPath();
		distanceSpeedModifier = Vector3.Distance(CurrentWaypoint.Position, NextWaypoint.Position);
	}

	// Update is called once per frame
	void Update() {
		#if UNITY_EDITOR
		if (isDirty) {
			ConstructFullPath();
			isDirty = false;
		}
#endif

		{ // Update Time
			float change = Time.deltaTime * movementSpeed;
			if (distanceSpeedModifier != 0) change *= (1 / distanceSpeedModifier);
			timeFromLastWaypoint += change;
		}

		if (timeFromLastWaypoint >= 1) {
			timeFromLastWaypoint -= 1;
			currentWaypointIndex = NextWaypointIndex;
			distanceSpeedModifier = Vector3.Distance(CurrentWaypoint.Position, NextWaypoint.Position);
		}

		platform.position = Vector3.Lerp(CurrentWaypoint.Position, NextWaypoint.Position, timeFromLastWaypoint);
	}

	public MovingPlatformWaypoint[] GetWaypoints() {
		return waypoints;
	}

#if UNITY_EDITOR
	private bool isDirty;

	public void SetDirty() {
		isDirty = true;
	}
#endif

	public void ConstructFullPath() {
		fullPath = new MovingPlatformWaypoint[waypoints.Length + 1];
		fullPath[0] = new MovingPlatformWaypoint(transform.position);

		for (int i = 0; i < waypoints.Length; i++) {
			fullPath[i + 1] = waypoints[i];
		}
	}

}
