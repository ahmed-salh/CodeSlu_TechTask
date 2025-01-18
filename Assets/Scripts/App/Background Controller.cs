
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private Image _backgroundImage;

    public void OnPointerDown(PointerEventData eventData)
    {
        _backgroundImage.sprite = GetComponent<Image>().sprite;
    }
}
