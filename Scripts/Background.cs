using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // マップスピード
    public float moveSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPlay)
        {
            // マップ循環
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
            if (transform.position.y < -10)
            {
                transform.position += new Vector3(0, 20f);
            }
        }
    }
}
