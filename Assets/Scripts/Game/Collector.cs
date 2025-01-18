using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) 
        {
            GameplayEventsHandler.onGameOver?.Invoke();
            Destroy(collision.gameObject);
        }
    }
}
