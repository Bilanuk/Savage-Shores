using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Steamworks;
using Steamworks.Data;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenu : Menu
{
    public GameObject menuPanel;
    private bool menuVisible = false;
    InputAction escapeAction;

    private void Start()
    {
        escapeAction = new InputAction("escape", binding: "<Keyboard>/escape");
        escapeAction.performed += ToggleGameMenu;
        escapeAction.Enable();
        menuPanel.SetActive(menuVisible);
    }

    private void ToggleGameMenu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            menuVisible = !menuVisible;
            menuPanel.SetActive(menuVisible);
            SetCursorVisibility(menuVisible);
        }
    }

    private void SetCursorVisibility(bool visible)
    {
        Cursor.visible = visible;
        Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void Disconnect()
    {
        //unsubscribe from escapeAction
        escapeAction.Disable();
        //leave steam lobby
        GameNetworkManager.instance.currentLobby?.Leave();
        NetworkManager.Singleton.Shutdown();
        Loader.Load(Loader.Scene.MainMenu);
    }
}