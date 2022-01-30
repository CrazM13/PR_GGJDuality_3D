using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	#region Inspector
	[Header("Components")]
	[SerializeField] private Transform targetTransform;
	[SerializeField] private Transform cameraTransform;

	[Header("Zoom")]
	[SerializeField] private float minDistance;
	[SerializeField] private float maxDistance;

	[Header("Pitch")]
	[SerializeField] private float minPitch;
	[SerializeField] private float maxPitch;

	[Header("Speed")]
	[SerializeField] private float rotationalSpeed;
	[SerializeField] private float zoomSpeed;
	#endregion

	private float yaw;
	private float pitch;
	private float zoom;

	public Vector3 Forward {
		get {
			Vector3 direction = cameraTransform.forward;

			return new Vector3(direction.x, 0, direction.z).normalized;
		}
	}

	public Vector3 Right {
		get {
			Vector3 direction = cameraTransform.right;

			return new Vector3(direction.x, 0, direction.z).normalized;
		}
	}

	void Start() {
		Cursor.lockState = CursorLockMode.Locked;

		zoom = minDistance + ((maxDistance - minDistance) * 0.5f);
	}

	void Update() {
		if (!targetTransform) return;

		UpdateMouseInputs();

		Vector3 center = targetTransform.position;
		//center = new Vector3(center.x, transform.position.y, center.z);

		Vector3 dir = AngleToDirection(pitch, yaw);
		Vector3 targetPos = center + (dir * zoom);

		transform.position = targetPos;

		cameraTransform.LookAt(targetTransform.position);
	}

	private void UpdateMouseInputs() {
		yaw += Input.GetAxis("Mouse X") * Time.deltaTime * rotationalSpeed;
		pitch = Mathf.Clamp(pitch + (Input.GetAxis("Mouse Y") * Time.deltaTime * rotationalSpeed), minPitch, maxPitch);
		zoom = Mathf.Clamp(zoom + (-Input.mouseScrollDelta.y * Time.deltaTime * zoomSpeed), minDistance, maxDistance);
	}

	private Vector3 AngleToDirection(float pitch, float yaw) {
		return Quaternion.Euler(pitch, yaw, 0) * Vector3.forward;
	}

}
