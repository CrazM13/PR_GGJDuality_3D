using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MovingPlatform))]
public class MovingPlatformEditor : Editor {
	
	private void OnSceneGUI() {

		MovingPlatform platform = target as MovingPlatform;

		MovingPlatformWaypoint[] waypoints = platform.GetWaypoints();

		for (int i = 0; i < waypoints.Length; i++) {
			HandleWaypoint(waypoints[i], platform);

			if (i + 1 < waypoints.Length) Handles.DrawDottedLine(waypoints[i].Position, waypoints[i + 1].Position, 2);
			else {
				Handles.DrawDottedLine(waypoints[i].Position, platform.transform.position, 2);
				Handles.DrawDottedLine(platform.transform.position, waypoints[0].Position, 2);
			}
		}

	}

	private void HandleWaypoint(MovingPlatformWaypoint waypoint, MovingPlatform platform) {
		Vector3 position, oldPosition;

		position = oldPosition = waypoint.Position;

		position = Handles.PositionHandle(position, Quaternion.identity);

		if (oldPosition != position) {
			Undo.RecordObject(platform, "Moving Platform");

			waypoint.SetPosition(position);

			platform.SetDirty();
		}
	}

}
