using UnityEngine;

public class StarsBehavior : MonoBehaviour
{
    private Animator starAnimator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip collectSound;

    void Start()
    {
        starAnimator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("El jugador obtuvo la energia");
            StartIsCollected();
        }
    }

    void StartIsCollected()
    {
        GetComponent<Collider>().enabled = false;
        starAnimator.SetBool("IsCollect", true);
        audioSource.PlayOneShot(collectSound);
    }
}
