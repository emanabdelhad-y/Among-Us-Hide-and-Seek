using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class Counter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countDownText;
    [SerializeField] public float remainingTime;
    public bool stop;

    // Start is called before the first frame update
    void Start()
    {
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (stop == false)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            else if (remainingTime < 0)
            {
                remainingTime = 0;
                countDownText.color = Color.red;
                //GameOver();
            }

            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            countDownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

    }
}
