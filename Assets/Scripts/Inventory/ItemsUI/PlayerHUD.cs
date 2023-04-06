using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    private ItemsUI itemsUI;

    private void Awake()
    {
        if (itemsUI == null)
        {
            itemsUI = GameObject.FindGameObjectWithTag("ItemsUI").GetComponent<ItemsUI>();
        }
    }

    public void UpdateWeaponUI(Item item)
    {
        itemsUI.UpdateInfo(item.itemIcon, item.itemName);
    }
}
