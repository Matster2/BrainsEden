﻿using UnityEngine;
using System.Collections;

public static class Events {

	public struct EventChecpointActivated {
		public gameobject checkpointObject;
	}
	
	public struct EventPhaseSwitched {
		public GameManager.EWorldPhase currentPhase;
	}

	public delegate void OnPhaseSwitched(EventPhaseSwitched eventPhaseSwitched);
	public static OnPhaseSwitched onPhaseSwitchedEvent;

	public delegate void OnStartPlay();
	public static OnStartPlay onStartPlayEvent;
	
	public delegate void OnPlayerDeath();
	public static OnPlayerDeath onPlayerDeathEvent;

	public delegate void OnCheckpointActivated(EventChecpointActivated eventChecpointActivated);
	public static OnCheckpointActivated OnCheckpointActivatedEvent;
}
