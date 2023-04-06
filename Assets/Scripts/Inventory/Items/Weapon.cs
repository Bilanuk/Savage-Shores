using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]

public class Weapon : Item
{

    public GameObject prefab;
    public int damage; 
    public float range;
    public ItemType weaponType;


}

public enum ItemType { Melee, Stuff}

