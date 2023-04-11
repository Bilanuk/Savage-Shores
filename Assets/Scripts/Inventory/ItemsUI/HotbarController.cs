using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarController : MonoBehaviour
{
    public int SlotsCount => gameObject.transform.childCount;

    private List<ItemsUI> slots = new List<ItemsUI>();

    KeyCode[] keys;

    private void KeyS()
    {
        keys = new KeyCode[SlotsCount];
        for (int i = 0; i < SlotsCount; i++)
        {
            keys[i] = (KeyCode)System.Enum.Parse(typeof(KeyCode), "Alpha" + (i + 1));
        }
    }

    private void Start()
    {
        SetUpHotbarSlots();
    }

    private void Update()
    {
        for (int i = 0; i < keys.Length; i++)
        {
            if (Input.GetKeyDown(keys[i]))
            {
                Debug.Log("Using " + slots[i]);
                return;
            }
        }
    }

    private void SetUpHotbarSlots()
    {
        for (int i = 0; i < SlotsCount; i++)
        {
            ItemsUI slot = gameObject.transform.GetChild(i).GetComponent<ItemsUI>();
            slots.Add(slot);
        }
    }
}
