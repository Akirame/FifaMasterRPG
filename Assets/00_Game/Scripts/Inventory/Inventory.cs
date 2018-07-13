﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
	#region Singleton
	private static Inventory instance;
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

	public Text playerSpeedText;
	public Text playerPowerText;

	[HideInInspector]
	public int playerSpeed;
	[HideInInspector]
	public int playerPower;

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

	void Update()
	{
		playerSpeedText.text = "SPEED: " + playerSpeed;
		playerPowerText.text = "SHOOTING POWER: " + playerPower;
	}

	public void Remove (Item item)
	{
		items.Remove(item);
		if (onItemChangeCallback != null)
			onItemChangeCallback.Invoke();
	}
}