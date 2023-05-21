using System.Collections;
using System.Collections.Generic;
using Steamworks;
using Steamworks.Data;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void PlaySound(AudioClip sound)
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }

    public void OpenOverlay()
    {
        SteamFriends.OpenOverlay("Friends");
    }

    public void QuitGame()
    {
        SteamClient.Shutdown();
        Application.Quit();
    }
}
