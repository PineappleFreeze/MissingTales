using UnityEngine;
using TMPro;

public class TimerBehavior : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float amoundTime = 60f;
    public bool isActive;

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
                NewTime(amoundTime);
            }
            else
            {
                amoundTime = 0;
                isActive = false;
            }
        }
    }

    void NewTime(float secondsTime)
    {
        if(secondsTime < 0)
        {
            secondsTime = 0;
        }
        float mins = Mathf.FloorToInt(secondsTime / 60);
        float segs = Mathf.FloorToInt(secondsTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", mins, segs);
    }
}

