using Michsky.UI.ModernUIPack;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private WindowManager windowManager;

    [SerializeField]
    private GameObject menuPanel;

    [SerializeField]
    private Animator animatorController;

    private bool drawerExpanded = false;

    public void StartGame() 
    {
        SceneManager.LoadScene(1);
    }

    public void GoTo(string panelName) 
    {
        windowManager.gameObject.SetActive(true);
        menuPanel.SetActive(false);

        switch (panelName)
        {
            case "Shop":
                windowManager.OpenPanel("Shop");
                break;
            case "Profile":
                windowManager.OpenPanel("Profile");
                break;
            case "Wheel":
                windowManager.OpenPanel("Wheel");
                break;
            case "Menu":
                windowManager.gameObject.SetActive(false);
                menuPanel.SetActive(true);
                if(drawerExpanded)
                    ExpandCollapseDrawer();
                break;
            default:
                break;
        }
    }

    public void ExpandCollapseDrawer() 
    {
        if (drawerExpanded)
        {
            animatorController.Play("Collapse");
            drawerExpanded = false;
        }
        else
        {
            animatorController.Play("Expand");
            drawerExpanded = true;
        }
    }
}
