using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    void Update()
    {
        // Rotate the game object that this script is attached to by 15 in the y axis,

        transform.Rotate(new Vector3(0, 15, 0) * Time.deltaTime);
    }
}
