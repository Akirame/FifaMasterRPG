using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
	#region Singleton
	private static EquipmentManager instance;
	public static EquipmentManager Get()
	{
		return instance;
	}

	void Awake()
	{
		instance = this;
	}
	#endregion

	public delegate void OnChangedEquip(Equipment newItem, Equipment previousItem);
	public OnChangedEquip onChangedEquipment;

	Equipment[] currentEquip;

	Inventory inventory;

	void Start()
	{
		inventory = Inventory.Get();

		int numSlots =  System.Enum.GetNames(typeof(PlayerEquipmentSlot)).Length;
		currentEquip = new Equipment[numSlots];
	}

	public void EquipItem (Equipment newItem)
	{
		int slotIndex = (int)newItem.playerEquipSlot;

		Equipment previousItem = null;

		if (currentEquip[slotIndex] != null)
		{
			previousItem = currentEquip[slotIndex];
			inventory.Add(previousItem);
		}

		if (onChangedEquipment != null)
		{
			onChangedEquipment.Invoke(newItem, previousItem);
		}

		currentEquip[slotIndex] = newItem;
	}

	public void Unequip(int slotIndex)
	{
		if (currentEquip[slotIndex] != null)
		{
			Equipment previousItem = currentEquip[slotIndex];
			inventory.Add(previousItem);

			currentEquip[slotIndex] = null;

			if (onChangedEquipment != null)
			{
				onChangedEquipment.Invoke(null, previousItem);
			}
		}
	}

	public void EmptyInventory()
	{
		for (int i = 0; i < currentEquip.Length; i++)
		{
			Unequip(i);
		}
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.U))
			EmptyInventory();
	}
}
