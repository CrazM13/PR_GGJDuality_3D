using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeOnCollide : MonoBehaviour {

	[SerializeField] private int sceneIndex;
	[SerializeField] private float delay;

	private bool isActive = false;
	private float timeUntilActivate;

	private void Update() {
		if (!isActive) return;
		timeUntilActivate -= Time.deltaTime;
		if (timeUntilActivate <= 0) {
			SceneManager.LoadScene(sceneIndex);
		}
	}

	private void OnCollisionEnter(Collision collision) {
		PlayerMovement player = collision.collider.GetComponent<PlayerMovement>();
		if (!player) return;

		timeUntilActivate = delay;
		isActive = true;
	}

}
