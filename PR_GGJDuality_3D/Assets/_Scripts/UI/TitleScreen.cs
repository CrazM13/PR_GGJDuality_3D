using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

	[SerializeField] private Image background;
	[SerializeField] private float backgroundSpeed;

	[SerializeField] private Image title;
	[SerializeField] private float titleIntensity;

	void Start() {

	}

	void Update() {
		background.transform.Rotate(Vector3.forward, Time.unscaledDeltaTime * backgroundSpeed);
		title.transform.Rotate(Vector3.forward, Mathf.Sin(Time.unscaledTime) * titleIntensity);

		if (Input.anyKeyDown) {
			SceneManager.LoadScene(1);
		}
	}
}
