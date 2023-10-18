using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private GameObject[] weaporns;
    private int weaponIndex = 0;

    [SerializeField]
    private Transform shootTransform;

    [SerializeField]
    private float shootInterval = 0.05f;
    private float lastShotTime = 0f;

    [SerializeField]
    private GameObject effectorArea;

    Vector3 resetPos;

    // Start is called before the first frame update
    void Start()
    {
        resetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPlay)
        {
            if(transform.position.y < resetPos.y + 1.5f)
            {
                Vector3 newPosition = transform.position + Vector3.up * moveSpeed * Time.deltaTime;
                transform.position = new Vector3(transform.position.x, Mathf.Min(newPosition.y, resetPos.y + 1.5f), transform.position.z);
            }
            // キャラー移動
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f);

            transform.position = new Vector3(toX, transform.position.y, transform.position.z);
            effectorArea.transform.position = new Vector3(toX, transform.position.y, transform.position.z);
            Shoot();
        }
    }

    //　弾丸発射
    void Shoot()
    {
        if (Time.time - lastShotTime > shootInterval)
        {
            Instantiate(weaporns[weaponIndex], shootTransform.position, Quaternion.identity);
            lastShotTime = Time.time;
        }
    }

    //　キャラ衝突、習得じの処理
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Boss")
        {
            transform.position = resetPos;
            GameManager.instance.SetGameOver();
        } else if(other.gameObject.tag == "Coin")
        {
            GameManager.instance.IncreaseCoin();
            Destroy(other.gameObject);
        } else if (other.gameObject.tag == "Item")
        {
            //GameManager.instance.IncreaseItem(other);
            Destroy(other.gameObject);
        }
    }

    public void Upgrade()
    {
        if(weaponIndex >= weaporns.Length)
        {
            weaponIndex = weaporns.Length - 1;
        }
    }
}
