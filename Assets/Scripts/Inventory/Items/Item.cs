using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Sprite itemIcon;

    public virtual void Use()
    {
        Debug.Log("Using " + itemName);
    }
}
