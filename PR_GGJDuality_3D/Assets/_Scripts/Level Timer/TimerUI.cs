using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimerUI : MonoBehaviour {

	[Header("Components")]
	[SerializeField] private Image backgroundPanel;
	[SerializeField] private Text textDisplay;
	[SerializeField] private Image progressDisplay;
	[SerializeField] private AudioSource tickSound;

	[Header("Colours")]
	[SerializeField] private Color defaultColor;
	[SerializeField] private Color timeOutColor;
	[SerializeField] private Color resetColor;


	public void OnTick(TimerTickEvent e) {
		textDisplay.text = e.source.TimeRemainingFormatted;
		progressDisplay.fillAmount = e.source.PercentRemaining;
		backgroundPanel.color = defaultColor;

		tickSound?.Play();
	}

	public void OnReset(TimerTickEvent e) {
		textDisplay.text = e.source.TimeRemainingFormatted;
		progressDisplay.fillAmount = 1;
		backgroundPanel.color = resetColor;
	}

	public void OnTimeOut(TimerTickEvent e) {
		textDisplay.text = "0:00";
		progressDisplay.fillAmount = 0;
		backgroundPanel.color = timeOutColor;
	}

}
