using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject coin;

    [SerializeField]
    private GameObject[] items;

    [SerializeField]
    public float EnemySpeed = 10f;

    private float minY = -6.5f;

    [SerializeField]
    private float hp = 1f;

    public void SetMoveSpeed(float EnemySpeed)
    {
        this.EnemySpeed = EnemySpeed;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //　モブが画面を離れると削除
        transform.position += Vector3.down * EnemySpeed * Time.deltaTime;
        if(transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }

    // 発射体とモブ衝突じに削除
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            Weaporn weapon = other.gameObject.GetComponent<Weaporn>();
            hp -= weapon.damage;
            if (hp <= 0)
            {
                if(gameObject.tag == "Boss")
                {
                    GameManager.instance.SetGameOver();
                }
                Destroy(gameObject);
                Instantiate(coin,transform.position,Quaternion.identity);
                //if(Random.Range(0, 9) == 0)
                //{
                //    Instantiate(items[Random.Range(0, 3)], transform.position, Quaternion.identity);
                //}
            }
            Destroy(other.gameObject);
        }
    }
}
