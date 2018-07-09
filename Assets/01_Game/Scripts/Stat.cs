using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
	[SerializeField]
	private int defaultValue;

	public int GetValue()
	{
		return defaultValue;
	}
}
