using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTickEvent {

	public readonly float remaining;
	public readonly Timer source;

	public TimerTickEvent(Timer sourceOfEvent) {
		this.source = sourceOfEvent;
		this.remaining = sourceOfEvent.TimeRemaining;
	}

}
