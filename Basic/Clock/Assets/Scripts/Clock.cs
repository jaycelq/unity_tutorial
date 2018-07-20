using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour {

    public Transform hoursTransform, minutesTransform, secondsTransform;

    public bool continuous;

    const float degreesPerHour = 30f;
    const float degreesPerMinute = 6f;
    const float degreesPerSecond = 6f;

    void UpdateDiscrete() {
        DateTime now = DateTime.Now;        
        hoursTransform.localRotation =
            Quaternion.Euler(0.0f, now.Hour * degreesPerHour, 0.0f);
        minutesTransform.localRotation = 
            Quaternion.Euler(0.0f, now.Minute * degreesPerMinute, 0.0f);
        secondsTransform.localRotation = 
            Quaternion.Euler(0.0f, now.Second * degreesPerSecond, 0.0f);
     }

    void UpdateContinuous() {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hoursTransform.localRotation =
            Quaternion.Euler(0f, (float)time.TotalHours * degreesPerHour, 0f);
        minutesTransform.localRotation =
            Quaternion.Euler(0f, (float)time.TotalMinutes * degreesPerMinute, 0f);
        secondsTransform.localRotation =
            Quaternion.Euler(0f, (float)time.TotalSeconds * degreesPerSecond, 0f);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (continuous) {
            UpdateContinuous();
        }
        else {
            UpdateDiscrete();
        }
	}
}
