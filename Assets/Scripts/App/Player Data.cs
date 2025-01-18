using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public Data Instance;

    public Sprite[] backgrounds;

    public Sprite[] avatars;
}

public class Data 
{
    public int savedAvatar;
    public int savedBackground;

}
