using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
public class NetworkUI : NetworkBehaviour
{
    public Button serverButton;
    public Button hostButton;
    public Button clientButton;

    private void Awake()
    {
        serverButton.onClick.AddListener(() => NetworkManager.Singleton.StartServer());
        hostButton.onClick.AddListener(() => NetworkManager.Singleton.StartHost());
        clientButton.onClick.AddListener(() => NetworkManager.Singleton.StartClient());
    }
}
