using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
	public PlayerEquipmentSlot playerEquipSlot;

	public int speedStat;
	public int powerStat;

	public override void Use()
	{
		base.Use();
		EquipmentManager.Get().EquipItem(this);
		RemoveFromInventory();
	}
}

public enum PlayerEquipmentSlot
{
	HEAD,
	SHIRT,
	HANDS,
	SHORTS,
	LEGS,
	SHOES
}
