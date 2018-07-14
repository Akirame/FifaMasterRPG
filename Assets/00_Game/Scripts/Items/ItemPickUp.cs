using UnityEngine;

public class ItemPickUp : Interactable
{
	public Item item;
	public float throwItemForce = 10f;
	private bool canPickUp;

	void Start()
	{
		AddSphereTrigger();
		canPickUp = false;

		Rigidbody rg = GetComponent<Rigidbody>();
		rg.AddForce((this.transform.up + this.transform.forward) * throwItemForce);
	}

	public override void Interact()
	{
		base.Interact(); // Executes Interact() inside Interactable class
		Inventory.Get().itemName = item.name;
		Inventory.Get().pickUpText.SetActive(true);
		//Debug.Log("Press B to pick up " + item.name);
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
		bool itemPickedUp = Inventory.Get().Add(item);

        if (itemPickedUp)
        {
            Inventory.Get().pickUpText.SetActive(false);
            Destroy(gameObject);            
        }
	}

	void OnTriggerEnter(Collider player)
	{
		if (player.tag == "Player")
			Interact();
	}

	void OnTriggerExit(Collider player)
	{
		if (player.tag == "Player")
		{
			Inventory.Get().pickUpText.SetActive(false);
			canPickUp = false;
		}
	}

	void AddSphereTrigger()
	{
		gameObject.AddComponent<SphereCollider>();
		SphereCollider trigger = GetComponent<SphereCollider>();
		trigger.isTrigger = true;
		trigger.radius = radius;
	}
}
