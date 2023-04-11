using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    private GameObject hotbar;
    private ItemsUI[] itemsUI;
    private int slotsCount;
    private KeyCode[] keys;

    private void Awake() { }

    public void UpdateWeaponUI(Item item, int index)
    {
        itemsUI[index].UpdateInfo(item.itemIcon, item.itemName);
    }

    private void KeyS()
    {
        keys = new KeyCode[slotsCount];
        for (int i = 0; i < slotsCount; i++)
        {
            keys[i] = (KeyCode)System.Enum.Parse(typeof(KeyCode), "Alpha" + (i + 1));
        }
    }

    private void Init()
    {
        if (hotbar == null)
        {
            hotbar = GameObject.FindGameObjectWithTag("HotBar").GetComponent<GameObject>();
        }

        slotsCount = hotbar.transform.childCount;
        itemsUI = new ItemsUI[slotsCount];
        for (int i = 0; i < slotsCount; i++)
        {
            itemsUI[i] = hotbar.transform.GetChild(i).GetComponent<ItemsUI>();
        }
    }

    private void Start()
    {
        Init();
        KeyS();
    }

    private void Update()
    {
        for (int i = 0; i < keys.Length; i++)
        {
            if (Input.GetKeyDown(keys[i]))
            {
                Debug.Log("Using " + itemsUI[i]);
                return;
            }
        }
    }
}
