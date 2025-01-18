using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private Image _backgroundImage;

    [SerializeField]
    private PlayerData _playerData;

    public void OnPointerDown(PointerEventData eventData)
    {
        _backgroundImage.sprite = GetComponent<Image>().sprite;
    }
}
