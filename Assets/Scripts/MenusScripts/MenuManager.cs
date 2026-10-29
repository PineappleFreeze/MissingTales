using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void GameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("InitialMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}