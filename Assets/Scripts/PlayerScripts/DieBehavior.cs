using UnityEngine;

public class DieBehavior : MonoBehaviour
{
    
    [SerializeField] private GameObject player;
    [SerializeField] private TimerBehavior timerBehavior;
    private PlayerMovementBehavior movementPlayer;


    [SerializeField] private GameObject losePanel;

    [SerializeField] private AudioSource FBXSource;
    [SerializeField] private AudioClip finalRoarSound;

    private bool isRoar = true;

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
        if(isRoar)
        {
            FinalRoarAudio();
            isRoar = false;
        }
        
    }

    void FinalRoarAudio()
    {
        FBXSource.volume = 0.3f; 
        FBXSource.clip = finalRoarSound;
        FBXSource.PlayOneShot(finalRoarSound);
    }
}
