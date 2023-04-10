using System.Collections;
using System.Collections.Generic;
using Steamworks;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerOverheadInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private RawImage playerIcon;

    public void SetPlayerName(string _name)
    {
        playerName.text = _name;
    }

    public async void SetPlayerIcon(ulong _steamId)
    {
        var img = await SteamFriends.GetLargeAvatarAsync(_steamId);
        playerIcon.texture = GetTextureFromImage(img.Value);
    }

    private Texture2D GetTextureFromImage(Steamworks.Data.Image img)
    {
        var tex = new Texture2D((int)img.Width, (int)img.Height, TextureFormat.RGBA32, false);
        tex.LoadRawTextureData(img.Data);
        tex.Apply();
        return tex;
    }
}