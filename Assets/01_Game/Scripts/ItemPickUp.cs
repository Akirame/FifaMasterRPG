using UnityEngine;

public class ItemPickUp : Interactable
{
	void Start()
	{
		AddSphereTrigger();
	}

	public override void Interact()
	{
		base.Interact(); // Executes Interact() inside Interactable class

		PickUp();
	}

	void PickUp()
	{
		Debug.Log("Press B to pick up " + name);
		// Add item to inventory
	}

	void OnTriggerEnter(Collider player)
	{
		if (player.tag == "Player")
			Interact();
	}

	void AddSphereTrigger()
	{
		gameObject.AddComponent<SphereCollider>();
		SphereCollider trigger = GetComponent<SphereCollider>();
		trigger.isTrigger = true;
		trigger.radius = radius;
	}
}
