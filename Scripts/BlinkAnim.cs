using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkAnim : MonoBehaviour
{
    float time;
    float timer;

    bool isActive;

    void Update()
    {
        if (!isActive)
            return;


        timer += Time.deltaTime;
        time += Time.deltaTime * 5f;

        if (timer >= 3f || !isActive)
        {
            isActive = false;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

            return;
        }
        if (time < 0.5f)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 - time);
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, time);
            if (time > 1f)
            {
                time = 0;
            }
        }

    }

    public void StartBlinking(bool flag)
    {
        isActive = flag;
        timer = 0f;
    }


}
