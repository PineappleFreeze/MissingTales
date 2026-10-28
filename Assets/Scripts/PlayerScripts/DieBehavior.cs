using UnityEngine;

public class DieBehavior : MonoBehaviour
{
    
    [SerializeField] private GameObject player;
    [SerializeField] private TimerBehavior timerBehavior;
    private PlayerMovementBehavior movementPlayer;


    [SerializeField] private GameObject losePanel;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip dieSound;
    [SerializeField] private float volumen;

    void Awake()
    {
        movementPlayer = player.GetComponent<PlayerMovementBehavior>();
    }
    void Update()
    {
        if(timerBehavior.isActive == false)
        {
            Die();
        }
    }

    void Die()
    {
        movementPlayer.enabled = false;
        losePanel.SetActive(true);
        ChangeAudio();
    }

    void ChangeAudio()
    {
        audioSource.volume = volumen; 
        audioSource.clip = dieSound;
        audioSource.PlayOneShot(dieSound);
    }
}
