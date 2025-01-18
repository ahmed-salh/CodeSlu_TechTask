using System.Collections;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DelayedDestroy());
    }

    private IEnumerator DelayedDestroy() 
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
