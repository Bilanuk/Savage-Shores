using System.Collections;
using System.Collections.Generic;
using Steamworks;
using Steamworks.Data;
using UnityEngine;

public class MainMenu : Menu
{
    public void CreateGame()
    {
        GameNetworkManager.instance.StartHost(10);
    }
}
