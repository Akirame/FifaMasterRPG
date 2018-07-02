using UnityEngine;

public class ItemPickUp : Interactable
{
	public Item item;

	private bool canPickUp;

	void Start()
	{
		AddSphereTrigger();
		canPickUp = false;
	}

	public override void Interact()
	{
		base.Interact(); // Executes Interact() inside Interactable class
		Debug.Log("Press B to pick up " + item.name);
		canPickUp = true;
	}

	void Update()
	{
		if (canPickUp)
		{
			// Add item to inventory
			if (Input.GetKeyDown(KeyCode.B))
				PickUp();
		}
	}

	void PickUp()
	{
		bool itemPickedUP = Inventory.Get().Add(item);
		
		if (itemPickedUP)
			Destroy(gameObject);
	}

	void OnTriggerEnter(Collider player)
	{
		if (player.tag == "Player")
			Interact();
	}

	void OnTriggerExit(Collider player)
	{
		if (player.tag == "Player")
			canPickUp = false;
	}

	void AddSphereTrigger()
	{
		gameObject.AddComponent<SphereCollider>();
		SphereCollider trigger = GetComponent<SphereCollider>();
		trigger.isTrigger = true;
		trigger.radius = radius;
	}
}
