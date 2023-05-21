using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class ScriptLoader : MonoBehaviour
{
    public static ScriptLoader Instance { get; private set; }

    public GameObject NetworkManagerPrefab;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        if (NetworkManager.Singleton == null)
        {
            Instantiate(NetworkManagerPrefab);
        }
    }
}
