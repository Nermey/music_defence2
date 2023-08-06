using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("DemoGame");
    }

    public void Options()
    {
        Debug.Log("Open options");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
