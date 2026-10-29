using UnityEngine;

public class TimerSoundManager : MonoBehaviour
{
    [SerializeField] private TimerBehavior timerBehavior;
    
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip tensionSound;
    [SerializeField] private float volumen = 1;

    void Update()
    {
        if(timerBehavior.amoundTime > 0.5)
        {
            if(timerBehavior.amoundTime <= 30)
            {
                TensionSound();
            }
        }
        else
        {
            audioSource.Stop();
        }

    }
    
    void TensionSound()
    {
        audioSource.volume = volumen; 
        audioSource.clip = tensionSound;
        audioSource.PlayOneShot(tensionSound);
    }

}
