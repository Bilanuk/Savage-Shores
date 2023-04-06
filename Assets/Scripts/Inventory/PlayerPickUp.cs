using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    [SerializeField]
    private float pickupRange;

    [SerializeField]
    private LayerMask pickupLayer;

    private Camera cam;

    private Inventory inventory;

    private void Start()
    {
        GetReferences();
    }

    private void Update()
    {
        Pickup();
    }

    private void Pickup()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, pickupRange, pickupLayer))
            {
                Weapon item = hit.transform.GetComponent<ItemObject>().item as Weapon;
                if (inventory.AddItem(item))
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }

    private void GetReferences()
    {
        cam = Camera.main;
        inventory = GetComponent<Inventory>();
    }
}
