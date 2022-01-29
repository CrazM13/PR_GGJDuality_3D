using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	private const float DEATH_VALUE = -10000;

	[Header("Components")]
	[SerializeField] private PlayerMovement movement;
	[SerializeField] private PlayerRagdoll ragdoll;
	[SerializeField] private Animator animations;

	[Header("Components")]
	[SerializeField] private float minDeathTime;

	private float deathTime = DEATH_VALUE;
	private Vector3 respawnPosition;

	// Start is called before the first frame update
	void Start() {
		ragdoll.StopRagdoll();
		ragdoll.Save();

		respawnPosition = transform.position;
	}

	// Update is called once per frame
	void Update() {
		UpdateAnimations();

		if (deathTime > 0) {
			deathTime -= Time.deltaTime;
		}
	}

	public void OnTimerTick(TimerTickEvent e) {
		if (deathTime <= 0 && deathTime > DEATH_VALUE) {
			Respawn();
			e.source.ResetTimer();
		}
	}

	public void OnTimerTimeOut(TimerTickEvent e) {
		if (deathTime != DEATH_VALUE) {
			if (deathTime <= 0) {
				Respawn();
				e.source.ResetTimer();
			}
		} else {
			Kill();
		}
	}

	private void Respawn() {
		ragdoll.StopRagdoll();
		ragdoll.Restore();

		EnableMovement();
		animations.enabled = true;

		movement.Teleport(respawnPosition);
		deathTime = DEATH_VALUE;
	}

	public void Kill() {
		if (deathTime != DEATH_VALUE) return;

		ragdoll.Save();
		ragdoll.StartRagdoll();

		DisableMovement();
		animations.enabled = false;

		deathTime = minDeathTime;
	}

	public void UpdateAnimations() {
		if (!animations) return;

		animations.SetBool("IsMoving", movement.IsMoving);
		animations.SetBool("IsGrounded", movement.IsGrounded);
	}

	private void DisableMovement() {
		movement.IsActive = false;
		movement.GetComponent<Rigidbody>().isKinematic = true;
		movement.GetComponent<Rigidbody>().detectCollisions = false;
	}

	private void EnableMovement() {
		movement.IsActive = true;
		movement.GetComponent<Rigidbody>().isKinematic = false;
		movement.GetComponent<Rigidbody>().detectCollisions = true;
	}

}
