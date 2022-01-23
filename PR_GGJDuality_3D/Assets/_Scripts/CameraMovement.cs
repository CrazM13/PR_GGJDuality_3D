using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	#region Inspector
	[Header("Components")]
	[SerializeField] private Transform targetTransform;
	[SerializeField] private Transform cameraTransform;

	[Header("Configuration")]
	[SerializeField] private float distance;
	[SerializeField] private float rotationalSpeed;
	[SerializeField] private float updateSpeed;
	#endregion

	private float angle;

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
	}

	void Update() {
		if (!targetTransform) return;

		UpdateMouseInputs();

		Vector3 center = targetTransform.position;
		center = new Vector3(center.x, transform.position.y, center.z);

		Vector3 dir = AngleToDirection(angle);
		Vector3 targetPos = center + (dir * distance);

		transform.position = targetPos;//Vector3.Lerp(transform.position, targetPos, Time.deltaTime * updateSpeed);

		cameraTransform.LookAt(targetTransform.position);
	}

	private void UpdateMouseInputs() {
		angle += -Input.GetAxis("Mouse X") * Time.deltaTime * rotationalSpeed;
	}

	private Vector3 AngleToDirection(float angle) {
		return new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
	}

}
