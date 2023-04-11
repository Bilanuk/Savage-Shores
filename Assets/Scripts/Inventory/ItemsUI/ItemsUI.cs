using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemsUI : MonoBehaviour
{
    [SerializeField]
    private Image icon;

    [SerializeField]
    private TextMeshProUGUI nameText;

    public void UpdateInfo(Sprite icon, string text)
    {
        this.icon.sprite = icon;
        this.nameText.text = text;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
