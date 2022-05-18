using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    private float timeElapsed = 0f;
    [SerializeField] private Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        TimeSpan time = TimeSpan.FromSeconds(timeElapsed);
        timeText.text = time.ToString(@"hh\:mm\:ss");
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(timeElapsed);
        timeText.text = time.ToString(@"hh\:mm\:ss");
    }
}
