using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
	public Image icon;
	public Button removeButton;

	Item item;

	public void AddItem(Item newItem)
	{
		item = newItem;

		icon.sprite = item.icon;
		icon.enabled = true;
		removeButton.interactable = true;
	}

	public void ClearSlot()
	{
		item = null;

		icon.sprite = null;
		icon.enabled = false;
		removeButton.interactable = false;
	}

	public void RemoveButton()
	{
		// Instantiate item object in the game world
		Instantiate(item.itemPrefab, PlayerController.Get().transform.position, Quaternion.identity);

		item.RemoveFromInventory();

		//Inventory.Get().Remove(item);
	}

	public void UseItem()
	{
		if (item != null)
		{
			item.Use();
		}
	}
}
