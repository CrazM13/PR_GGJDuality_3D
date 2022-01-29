using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	#region Inspector
	[Header("Components")]
	[SerializeField] private Transform modelTransform;
	[SerializeField] private Rigidbody physicsbody;
	[SerializeField] private CameraMovement cameraControls;

	[Header("Movement")]
	[SerializeField] private float movementSpeed;

	[Header("Jumping")]
	[SerializeField] private int maxJumpCount;
	[SerializeField] private float jumpForce;
	[SerializeField] private bool canMoveInAir;
	#endregion

	private Vector3 deathPos;

	public bool IsActive { get; set; } = true;

	public bool IsMoving => playerMovement.sqrMagnitude > 0;
	public bool IsGrounded => grounded;

	#region Unity Events
	void Update() {
		if (!IsActive) return;

		if (canMoveInAir || grounded) UpdateMovementInputs(grounded ? 1 : 0.75f);
		UpdateJumpInputs();

		if (facingDir != Vector3.zero) {
			modelTransform.rotation = Quaternion.Lerp(modelTransform.rotation, Quaternion.LookRotation(facingDir, transform.up), Time.deltaTime * 10);
		}
	}

	private void FixedUpdate() {
		if (!physicsbody) return;

		if (forcedMovement != Vector3.zero) {
			physicsbody.MovePosition(transform.position + forcedMovement);
			forcedMovement = Vector3.zero;
		}

		if (playerMovement != Vector3.zero) {
			Vector3 newVelocity = playerMovement * movementSpeed;
			physicsbody.velocity = new Vector3(newVelocity.x, physicsbody.velocity.y, newVelocity.z);
		}

		if (shouldJump) {
			physicsbody.AddForce((transform.up * jumpForce) + forcedMovement, ForceMode.Impulse);
			jumpCount++;
			shouldJump = false;
			grounded = false;
		}

		if (playerMovement != Vector3.zero) {
			facingDir = playerMovement.normalized;
			playerMovement = Vector3.zero;
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
	private Vector3 forcedMovement;
	private Vector3 playerMovement;
	private Vector3 facingDir;

	private void UpdateMovementInputs(float scale) {
		playerMovement += cameraControls.Right * Input.GetAxis("Horizontal") * scale;
		playerMovement += cameraControls.Forward * Input.GetAxis("Vertical") * scale;
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
	public void Teleport(Vector3 position) {
		physicsbody.position = position;
	}

	public void ForceMovePlayer(Vector3 forcedMovement) {
		this.forcedMovement += forcedMovement;
	}
	#endregion


}
