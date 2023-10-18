using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaporn : MonoBehaviour
{
    [SerializeField]
    private float atkSpeed = 10f;

    public float damage = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * atkSpeed * Time.deltaTime;
    }
}
