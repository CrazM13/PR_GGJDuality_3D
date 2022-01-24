using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	#region Inspector
	[Header("Components")]
	[SerializeField] private Transform modelTransform;
	[SerializeField] private Rigidbody physicsbody;
	[SerializeField] private CapsuleCollider playerCollider;
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

		if (canMoveInAir || grounded) UpdateMovementInputs(grounded ? 1 : 0.75f);
		UpdateJumpInputs();

		if (facingDir != Vector3.zero) {
			modelTransform.rotation = Quaternion.Lerp(modelTransform.rotation, Quaternion.LookRotation(facingDir, transform.up), Time.deltaTime * 10);
		}

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
			physicsbody.velocity = new Vector3(physicsbody.velocity.x * 0, physicsbody.velocity.y * 1, physicsbody.velocity.z * 0);
			physicsbody.MovePosition(transform.position + (movement * Time.deltaTime));
		}

		if (shouldJump) {
			physicsbody.AddForce((transform.up * jumpForce) + movement, ForceMode.Impulse);
			jumpCount++;
			shouldJump = false;
			grounded = false;
		}

		if (movement != Vector3.zero) {
			facingDir = movement.normalized;
			movement = Vector3.zero;
		}
	}

	private void OnCollisionStay(Collision collision) {
		if (physicsbody.velocity.y > 0 || grounded) return;
		
		for (int i = 0; i < collision.contactCount; i++) {
			Vector3 normal = collision.GetContact(i).normal;
		
			if (Vector3.Angle(normal, transform.up) < 30) {
				jumpCount = 0;
				grounded = true;
			}
		}
	}
	#endregion

	#region Movement
	private Vector3 movement;
	private Vector3 facingDir;

	private void UpdateMovementInputs(float scale) {
		movement += cameraControls.Right * Input.GetAxis("Horizontal") * movementSpeed * scale;
		movement += cameraControls.Forward * Input.GetAxis("Vertical") * movementSpeed * scale;
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
		physicsbody.velocity = Vector3.zero;
	}

	public void ForceMovePlayer(Vector3 forcedMovement) {
		movement += forcedMovement;
	}
	#endregion


}
