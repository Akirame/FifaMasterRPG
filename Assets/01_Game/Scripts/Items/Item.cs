using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
	new public string name = "Item name";
	public Sprite icon = null;

	public virtual void Use()
	{
		// Use item logic

		Debug.Log("Using " + name);
	}
}
