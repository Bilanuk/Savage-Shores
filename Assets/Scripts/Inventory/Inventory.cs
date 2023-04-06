using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private Item[] items;

    private void Init()
    {
        items = new Item[5];
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
        return (Weapon)items[index];
    }

    private void Start()
    {
        Init();
    }
}
