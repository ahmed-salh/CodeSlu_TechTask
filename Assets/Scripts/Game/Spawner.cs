using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private GameObject hoopPrefab;

    [SerializeField]
    private GameObject textPrefab;

    [SerializeField]
    private float shootForce;

    [SerializeField]
    private float shootSweepAngle;

    [SerializeField]
    private Transform canvas;

    private Vector2 hoopPosition, ballPosition;


    private void OnEnable()
    {
        GameplayEventsHandler.onScore += StartDelayedSpawn;
        GameplayEventsHandler.onScore += SpawnText;
        
        GameplayEventsHandler.onGameStart += SpawnHoop;
        GameplayEventsHandler.onGameStart += StartShooting;

    }

    private void OnDisable()
    {
        GameplayEventsHandler.onScore -= StartDelayedSpawn;
        GameplayEventsHandler.onScore -= SpawnText;

        GameplayEventsHandler.onGameStart -= SpawnHoop;
        GameplayEventsHandler.onGameStart -= StartShooting;

    }


    private void SpawnHoop()
    {
        hoopPosition = new Vector2(0.1f * Random.Range(-20, 20), 0.1f * Random.Range(-20, 20));

        Instantiate(hoopPrefab, hoopPosition, Quaternion.identity);

    }

    private void StartShooting()
    {
        ballPosition = new Vector2(transform.position.x + .1f * Random.Range(-20, 20), transform.position.y);

        GameObject newBall = Instantiate(ballPrefab, ballPosition, Quaternion.identity);

        Rigidbody2D rigidbody = newBall.GetComponent<Rigidbody2D>();

        float randomAngle = Random.Range(-shootSweepAngle * Mathf.Deg2Rad, shootSweepAngle * Mathf.Deg2Rad);

        Vector2 randomDirection = new Vector2(-Mathf.Sin(randomAngle), Mathf.Cos(randomAngle));

        Vector2 ballToHoopLine = hoopPosition - ballPosition;

        while (Vector2.Dot(ballToHoopLine, randomDirection) <= 0.1) 
        {
            float deflectionAngle = randomAngle + 10 * Mathf.Deg2Rad;

            randomDirection = new Vector2(-Mathf.Sin(deflectionAngle), Mathf.Cos(deflectionAngle));

            ballToHoopLine = hoopPosition - ballPosition;
        }
      

        rigidbody.AddForce(shootForce * randomDirection, ForceMode2D.Impulse);

    }

    private void StartDelayedSpawn() 
    {
        StartCoroutine(DelayedSpawn());
    }

    private IEnumerator DelayedSpawn()
    {
        yield return new WaitForSeconds(1);
        SpawnHoop();
        StartShooting();
    }

    private void SpawnText() 
    {
        Instantiate(textPrefab, Camera.main.WorldToScreenPoint(hoopPosition), Quaternion.identity, canvas);
    }




}