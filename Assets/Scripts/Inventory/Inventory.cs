using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int slots = 5;

    [SerializeField]
    private Item[] items;
    private PlayerHUD HUD;

    private void Init()
    {
        items = new Item[slots];
    }

    public bool AddItem(Item item)
    {
        bool isadded = false;
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = item;
                isadded = true;
                //HUD.UpdateWeaponUI(item, i);
                break;
            }
        }

        return isadded;
    }

    public void RemoveItem(Item item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == item)
            {
                items[i] = null;
                break;
            }
        }
    }

    public Weapon GetItem(int index)
    {
        return items[index] as Weapon;
    }

    private void Start()
    {
        GetReferences();
        Init();
    }

    private void GetReferences()
    {
        HUD = GetComponent<PlayerHUD>();
    }

    public int GetSlotsCount()
    {
        return slots;
    }
}
