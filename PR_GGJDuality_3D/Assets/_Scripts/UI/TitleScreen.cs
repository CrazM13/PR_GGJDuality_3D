using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

	private readonly Color SHADOW_COLOUR = new Color(0, 0, 0, 0.4f);

	[SerializeField] private Image background;
	[SerializeField] private float backgroundSpeed;

	[SerializeField] private Image title;
	[SerializeField] private float titleIntensity;

	[SerializeField] private Image message;
	[SerializeField] private Image messageShadow;
	[SerializeField] private float messageIntensity;

	[SerializeField] private float forceViewTime = 5f;

	private float remainingViewTime;
	private float fadeTime;

	void Start() {
		remainingViewTime = forceViewTime;

		message.color = Color.clear;
		messageShadow.color = Color.clear;
	}

	void Update() {
		background.transform.Rotate(Vector3.forward, Time.unscaledDeltaTime * backgroundSpeed);
		title.transform.Rotate(Vector3.forward, Mathf.Sin(Time.unscaledTime) * titleIntensity);
		message.transform.Rotate(Vector3.forward, Mathf.Sin(Time.unscaledTime + Mathf.PI) * messageIntensity);

		if (remainingViewTime > 0) {
			remainingViewTime -= Time.unscaledDeltaTime;
		} else {
			if (fadeTime <= 1) {
				fadeTime += Time.unscaledDeltaTime;
				message.color = Color.Lerp(Color.clear, Color.white, fadeTime);
				messageShadow.color = Color.Lerp(Color.clear, SHADOW_COLOUR, fadeTime);
			}
		}

		if (remainingViewTime <= 0 && Input.anyKeyDown) {
			SceneManager.LoadScene(1);
		}
	}
}
