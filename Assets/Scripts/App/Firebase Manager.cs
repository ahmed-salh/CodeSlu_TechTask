using Firebase;
using Firebase.Auth;
using Firebase.Extensions;

using UnityEngine;
using UnityEngine.UI;

public class FirebaseManager : MonoBehaviour
{
    private FirebaseAuth auth;

    [SerializeField]
    private Text userText;

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                InitializeFirebase();
                if(auth.CurrentUser == null)
                    SignInAnonymously();

                userText.text = ("User ID: " + auth.CurrentUser.UserId);


            }
            else
            {
                Debug.LogError($"Could not resolve all Firebase dependencies: {task.Result}");
            }
        });

    }

    void InitializeFirebase()
    {
        auth = FirebaseAuth.DefaultInstance;
        Debug.Log("Firebase initialized!");
    }

    public void SignInAnonymously()
    {
        auth.SignInAnonymouslyAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted && !task.IsFaulted)
            {
                FirebaseUser user = task.Result.User;
            }
            else
            {
                Debug.LogError("Anonymous sign-in failed: " + task.Exception);
            }
        });
    }

    public void UpleadData() 
    {
    
    }
}