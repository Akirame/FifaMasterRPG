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
        if (!instance)
            instance = this;
        else
            Destroy(this);
    }
	#endregion

	public delegate void OnItemChanged();
	public OnItemChanged onItemChangeCallback;

	public int numberOfSlots = 20;

	public List<Item> items = new List<Item>();

	public bool Add (Item item)
	{
		if (items.Count < numberOfSlots)
		{
			items.Add(item);

			if (onItemChangeCallback != null)
				onItemChangeCallback.Invoke();

			return true;
		}
		else
		{
			Debug.Log("INVENTORY FULL");
			return false;
		}
	}
	
	public void Remove (Item item)
	{
		items.Remove(item);
		if (onItemChangeCallback != null)
			onItemChangeCallback.Invoke();
	}
}
