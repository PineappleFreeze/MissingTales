using UnityEngine;
using TMPro;

public class TimerBehavior : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float amoundTime = 60f;
    [SerializeField] private bool isActive;

    void Awake()
    {
        isActive = true;
    }
    void Update()
    {
        if(isActive)
        {
            if(amoundTime > 0)
            {
                amoundTime -= Time.deltaTime;

            }
            else
            {
                amoundTime = 0;
                isActive = false;

            }
        }
    }
}

