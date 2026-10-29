using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool isPause { get; private set;}

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);


        Time.timeScale = 1f;
        isPause = false;
    }

    void Update()
    {
        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        isPause = !isPause;
        Time.timeScale = isPause ? 0f : 1f;
    }
}
