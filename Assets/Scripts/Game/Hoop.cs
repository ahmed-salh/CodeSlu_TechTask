using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoop : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) 
        {
            GameplayEventsHandler.onScore.Invoke();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
