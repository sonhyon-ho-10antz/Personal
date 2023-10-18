using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public CameraShake cameraShake;

    private int coin = 0;

    [HideInInspector]
    public bool isPlay = false;

    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject gameOvePanel;

    [SerializeField]
    private Image gameOvePanelChar;

    [SerializeField]
    private Sprite[] charList;

    [SerializeField]
    private GameObject gameTopPage;

    [SerializeField]
    public GameObject changeChar;

    public int selectCharNum = 0;

    public string itemName;
    public int itemNum;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

    }

    public void IncreaseCoin()
    {
        coin++;
        text.SetText(coin.ToString());

        if (coin % 30 == 0)
        {
            Player player = FindObjectOfType<Player>();
            if(player != null)
            {
                player.Upgrade();
            }
        }
    }

    //public void IncreaseItem(Collider2D other)
    //{
    //    EffectArea effectArea = FindObjectOfType<EffectArea>();
    //    itemName = other.gameObject.name;
    //    int.TryParse(itemName.Replace("Item", "").Replace("(Clone)", ""), out itemNum);

    //    switch (itemNum)
    //    {
    //        case 1:
    //            // アイテム１
    //            Debug.Log(itemNum);
    //            break;
    //        case 2:
    //            // アイテム２
    //            Debug.Log(itemNum);
    //            break;
    //        case 3:
    //            // アイテム３
    //            Debug.Log(itemNum);
    //            break;
    //        case 4:
    //            // アイテム４
    //            Debug.Log(itemNum);
    //            break;
    //    }
    //}

    public void SetGameOver()
    {
        isPlay = false;
        cameraShake.VibrateForTime(1f);
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        enemySpawner.StopEnemyRoutine();
        player.SetActive(false);

        Invoke("ShowGameOverPanel",2.5f);
    }

    void ShowGameOverPanel()
    {
        isPlay = false;

        gameOvePanelChar.sprite = charList[selectCharNum-1] ;
        gameOvePanel.SetActive(true);
    }

    public void GameStart()
    {
        coin = 0;
        text.SetText(coin.ToString());
        isPlay = true;
        gameOvePanel.SetActive(false);
        changeChar.SetActive(false);
        
        player.SetActive(true);

        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        enemySpawner.StartEnemyRoutine();

    }

    public void ChangeCharBtn()
    {
        GameObject gameObject = EventSystem.current.currentSelectedGameObject;
        selectCharNum = int.Parse(gameObject.GetComponentInChildren<Text>().text);


        ChangeCharacter changeCharacter = FindObjectOfType<ChangeCharacter>();

        changeCharacter.ChangeChar(selectCharNum);

    }

    public void OpenChangeChar()
    {
        changeChar.SetActive(true);
        gameOvePanel.SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        enemySpawner.StopEnemyRoutine();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
