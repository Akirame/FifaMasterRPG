using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{
	[SerializeField]
	private int defaultValue;

	private List<int> modsList = new List<int>();

	public int GetValue()
	{
		int totalValue = defaultValue;
		// Executes logic on all the elements in the list
		for (int i = 0; i < modsList.Count; i++)
			totalValue += modsList[i];

		return totalValue;
	}

	public void AddModifier(int mod)
	{
		if (mod != 0)
			modsList.Add(mod);
	}

	public void RemoveModifier(int mod)
	{
		if (mod != 0)
			modsList.Remove(mod);
	}
}
