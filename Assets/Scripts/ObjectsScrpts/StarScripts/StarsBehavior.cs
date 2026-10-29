using UnityEngine;

public class StarsBehavior : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip collectSound;
    [SerializeField] private GameObject startObject;


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
        startObject.SetActive(false);
        audioSource.PlayOneShot(collectSound);
    }
}
