using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeAmount;
    float shakeTime;
    Vector3 initialPosition;

    public void VibrateForTime(float time)
    {
        shakeTime = time;
    }

    private void Start()
    {
        initialPosition = new Vector3(0f, 0f, -5f);
    }

    private void Update()
    {
        if(shakeTime > 0)
        {
            transform.position = Random.insideUnitSphere * shakeAmount + initialPosition;
            shakeTime -= Time.deltaTime;
        }
        else
        {
            shakeTime = 0.0f;
            transform.position = initialPosition;
        }
    }

}
