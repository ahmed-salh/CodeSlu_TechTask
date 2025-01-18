using Firebase;
using Firebase.Auth;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ProfilePictureChanger : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private Image _profilePic;

    public void OnPointerDown(PointerEventData eventData)
    {
        _profilePic.sprite = GetComponent<Image>().sprite;
    }

}
