using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public int maxHealth = 100;
	private int currentHealth;

	public Stats speed;
	public Stats power;
	public Stats protection;

	void Awake()
	{
		currentHealth = maxHealth;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.H))
		{
			Debug.Log("Speed Stat: " + speed.GetValue().ToString());
		}
	}

	void Start()
	{
		EquipmentManager.Get().onChangedEquipment += OnEquipmentChanged;
	}

	public void damagePlayer(int damage)
	{
		//  Reduces damage according to player's equipment
		damage -= protection.GetValue();
		if (damage < 0)
			damage = 0;

		currentHealth -= damage;
		if (currentHealth <= 0)
			Die();
	}

	public void Die()
	{
		// kill player
	}

	// Get called every time an item is Equiped
	void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
	{
		// Adds the stats modification from the item, to the player
		if (newItem != null)
		{
			speed.AddModifier(newItem.speedStat);
			power.AddModifier(newItem.powerStat);
		}

		// Removes the modifiers from the old item equiped
		if (oldItem != null)
		{
			speed.RemoveModifier(oldItem.speedStat);
			power.RemoveModifier(oldItem.powerStat);
		}
	}

	public int GetPlayerHealth()
	{
		return currentHealth;
	}
}
