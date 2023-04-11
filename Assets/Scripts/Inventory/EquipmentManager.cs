using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField]
    private Transform ItemHolderR = null;
    private Animator anim;
    private Inventory inventory;

    private int slotsCount;
    KeyCode[] keyCodes;

    private void Start()
    {
        GetReferences();
        Init();
    }

    private void Update()
    {
        Press();
    }

    private void Press()
    {
        for (int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                HideItem();
                if (inventory.GetItem(i) != null)
                {
                    EquipItem(inventory.GetItem(i).prefab, i);
                }
            }
        }
    }

    private void EquipItem(GameObject item, int id)
    {
        Item item2 = inventory.GetItem(id);
        item.transform.position = Vector3.zero;
        Instantiate(item, ItemHolderR);
    }

    private void HideItem()
    {
        foreach (Transform child in ItemHolderR)
        {
            Destroy(child.gameObject);
        }
    }

    private void GetReferences()
    {
        //anim=GetComponentInChildren<Animater>(); //Get animation for item
        inventory = GetComponent<Inventory>();
    }

    private void Init()
    {
        slotsCount = inventory.GetSlotsCount();
        keyCodes = new KeyCode[slotsCount];
        for (int i = 0; i < slotsCount; i++)
        {
            keyCodes[i] = (KeyCode)System.Enum.Parse(typeof(KeyCode), "Alpha" + (i + 1));
        }
    }
}
