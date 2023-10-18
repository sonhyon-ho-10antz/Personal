using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{

    public GameObject char1;
    public GameObject char2;
    public GameObject char3;
    public GameObject char4;
    public GameObject char5;


    public void ChangeChar(int selectCharNum)
    {
        char1.SetActive(false);
        char2.SetActive(false);
        char3.SetActive(false);
        char4.SetActive(false);
        char5.SetActive(false);

        switch (selectCharNum)
        {
            case 1:
                char1.SetActive(true);
                break;
            case 2:
                char2.SetActive(true);
                break;
            case 3:
                char3.SetActive(true);
                break;
            case 4:
                char4.SetActive(true);
                break;
            case 5:
                char5.SetActive(true);
                break;
        }
    }
}
