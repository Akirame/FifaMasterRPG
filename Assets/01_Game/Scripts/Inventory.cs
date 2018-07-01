using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	#region Singleton
	public static Inventory instance;
	public static Inventory Get()
	{
		return instance;
	}

	void Awake()
	{
		instance = this;
	}
	#endregion

	public List<Item> items = new List<Item>();

	public void AddItem (Item item)
	{
		items.Add(item);
	}
	
	public void RemoveItem (Item item)
	{
		items.Remove(item);
	}
}
