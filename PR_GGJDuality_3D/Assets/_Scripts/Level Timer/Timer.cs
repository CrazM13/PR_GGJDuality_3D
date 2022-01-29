using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour {
	[Header("Tickrate")]
	[SerializeField] private float setTime;
	[SerializeField] private float tickInterval;

	[Header("Events")]
	[SerializeField] private UnityEvent<TimerTickEvent> OnTick;
	[SerializeField] private UnityEvent<TimerTickEvent> OnTimeOut;
	[SerializeField] private UnityEvent<TimerTickEvent> OnReset;

	private float fullTimerAmount;
	private float elapsedTime;

	private float timeSinceTick;

	public float TimeRemaining => fullTimerAmount - elapsedTime;
	public float TimeElapsed => elapsedTime;
	public string TimeRemainingFormatted => $"{Mathf.FloorToInt((fullTimerAmount - elapsedTime) / 60):00}:{Mathf.FloorToInt(fullTimerAmount - elapsedTime) % 60:00}";
	public string TimeElapsedFormatted => $"{Mathf.FloorToInt(elapsedTime / 60):00}:{Mathf.FloorToInt(elapsedTime) % 60:00}";
	public float PercentRemaining => 1 - PercentElapsed;
	public float PercentElapsed => elapsedTime / fullTimerAmount;

	public float LocalTimeScale { get; set; } = 1;

	// Start is called before the first frame update
	void Start() {
		ResetTimer(setTime);
	}

	// Update is called once per frame
	void Update() {
		UpdateTimer(Time.deltaTime);
	}

	public void UpdateTimer(float timeElapsed) {
		timeSinceTick += timeElapsed * LocalTimeScale;

		if (timeSinceTick >= 1) {
			timeSinceTick = 0;
			elapsedTime += tickInterval;
			OnTick.Invoke(new TimerTickEvent(this));

			if (elapsedTime >= fullTimerAmount) {
				elapsedTime = fullTimerAmount;
				OnTimeOut.Invoke(new TimerTickEvent(this));
			}
		}

	}

	public void ResetTimer() {
		ResetTimer(setTime);
	}

	public void ResetTimer(float timeRemaining) {
		fullTimerAmount = timeRemaining;
		elapsedTime = 0;
		OnReset.Invoke(new TimerTickEvent(this));
	}

}
