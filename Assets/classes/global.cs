﻿using UnityEngine;
using System.Collections;

public enum mode {play , build};

public static class global{
	public static GameObject mouseOver;
	public static mode mode = mode.play;
	public static int gravity = 100;
}