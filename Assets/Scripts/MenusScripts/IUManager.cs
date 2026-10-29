using UnityEngine;

public class IUManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameManager gameManager;

    void Update()
    {
        if(gameManager.isPause == true)
        {
           pausePanel.SetActive(true);
        }
        else
        {
            pausePanel.SetActive(false);
        }
    }
}
