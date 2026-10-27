using UnityEngine;
using TMPro;

public class StarsManagerCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI starsText;
    [SerializeField] private int amoundCollected;

    void Start()
    {
        LoadInterface();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Star"))
        {
            amoundCollected++;
            LoadInterface();
        }
    }

    void LoadInterface()
    {
        if (starsText != null)
        {
            starsText.text = amoundCollected.ToString();
        }
    }

}
