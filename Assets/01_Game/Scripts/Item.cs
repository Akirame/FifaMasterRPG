using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Iventory/Item")]
public class Item : ScriptableObject
{
	new public string name = "Item name";
	public Sprite icon = null;
}
