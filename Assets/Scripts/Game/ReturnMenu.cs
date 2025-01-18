
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnMenu : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(()=>{ SceneManager.LoadScene(0); });
    }

}
