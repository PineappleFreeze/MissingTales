using UnityEngine;

public class WinBehavior : MonoBehaviour
{
    [SerializeField] private StarsManagerCollector starManager;

    [SerializeField] private GameObject winPanel;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip winSound;
    [SerializeField] private float volumen = 0.5f;

    [SerializeField] private GameObject player;
    private PlayerMovementBehavior movementPlayer;

    void Awake()
    {
        movementPlayer = player.GetComponent<PlayerMovementBehavior>();
    }

    void Update()
    {
        if(starManager.amoundCollected == 5)
        {
            winPanel.SetActive(true);
            ChangeAudio();
            movementPlayer.enabled = false;
        }
    }

    void ChangeAudio()
    {
        audioSource.volume = volumen; 
        audioSource.clip = winSound;
        audioSource.PlayOneShot(winSound);
    }
}
