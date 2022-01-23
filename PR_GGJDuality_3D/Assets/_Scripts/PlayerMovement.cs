using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	#region Inspector
	[Header("Components")]
	[SerializeField] private Rigidbody physicsbody;
	[SerializeField] private CameraMovement cameraControls;

	[Header("Movement")]
	[SerializeField] private float movementSpeed;

	[Header("Jumping")]
	[SerializeField] private int maxJumpCount;
	[SerializeField] private float jumpForce;
	[SerializeField] private bool canMoveInAir;

	[Header("Debug")]
	[SerializeField] private bool kill;
	#endregion

	private Vector3 deathPos;

	#region Unity Events
	void Start() {
		deathPos = transform.position;
	}

	void Update() {
		if (canMoveInAir || grounded) UpdateMovementInputs();
		UpdateJumpInputs();

		#region Debug
		if (kill) {
			Die();
			kill = false;
		}
		#endregion

	}

	private void FixedUpdate() {
		if (!physicsbody) return;

		if (movement != Vector3.zero) {
			physicsbody.MovePosition(transform.position + (movement * Time.deltaTime));
		}

		if (shouldJump) {
			physicsbody.AddForce((transform.up * jumpForce) + movement, ForceMode.Impulse);
			jumpCount++;
			shouldJump = false;
			grounded = false;
		}

		if (movement != Vector3.zero) movement = Vector3.zero;
	}

	private void OnCollisionEnter(Collision collision) {
		Vector3 normal = collision.GetContact(0).normal;

		if (Vector3.Angle(normal, transform.up) < 30) {
			jumpCount = 0;
			grounded = true;
		}
	}
	#endregion

	#region Movement
	private Vector3 movement;

	private void UpdateMovementInputs() {
		movement += cameraControls.Right * Input.GetAxis("Horizontal") * movementSpeed;
		movement += cameraControls.Forward * Input.GetAxis("Vertical") * movementSpeed;
	}
	#endregion

	#region Jump
	private bool grounded;
	private bool shouldJump;
	private int jumpCount = 0;

	private bool isJumpDown = false;

	private void UpdateJumpInputs() {
		bool isJumpDownNew = Input.GetAxis("Jump") > 0;

		if (!isJumpDown && isJumpDownNew) {
			if (jumpCount < maxJumpCount) shouldJump = true;
		}
		isJumpDown = isJumpDownNew;
	}
	#endregion

	#region Interface
	public void Die() {
		transform.position = deathPos;
	}

	public void ForceMovePlayer(Vector3 forcedMovement) {
		movement += forcedMovement;
	}
	#endregion

}
