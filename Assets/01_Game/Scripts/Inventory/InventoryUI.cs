using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
	public Transform itemsParent;

	public GameObject inventoryUI;

	Inventory inventory;

	InventorySlot[] slots;

	void Start ()
	{
		inventory = Inventory.Get();
		inventory.onItemChangeCallback += UpdateUI;

		slots = GetComponentsInChildren<InventorySlot>();
	}
	
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			inventoryUI.SetActive(!inventoryUI.activeSelf);

			// See if opening the inventory should stop the game,
			// or just the player movement
		}
	}

	void UpdateUI()
	{
		// Loop through all the inventory slots
		for (int i = 0; i < slots.Length; i++)
		{
			// Adds/Clears items on the slots 
			if (i < inventory.items.Count)
				slots[i].AddItem(inventory.items[i]);
			else
				slots[i].ClearSlot();
		}
	}
}
