using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [Header("Level Button Map 1")]
    public GameObject buttonlvl2;
    public GameObject buttonlvl3;
    public GameObject buttonlvl4;
    public GameObject buttonlvl5;
    public GameObject buttonlvl6;
    public GameObject buttonlvl7;
    public GameObject buttonlvl8;
    public GameObject buttonlvl9;
    public GameObject buttonlvl10;

    [Header("Level button locked")]
    public GameObject buttonlvl2_lock;
    public GameObject buttonlvl3_lock;
    public GameObject buttonlvl4_lock;
    public GameObject buttonlvl5_lock;
    public GameObject buttonlvl6_lock;
    public GameObject buttonlvl7_lock;
    public GameObject buttonlvl8_lock;
    public GameObject buttonlvl9_lock;
    public GameObject buttonlvl10_lock;


    // Start is called before the first frame update
    void Awake()
    {
        RefreshMap();
    }

    // Update is called once per frame
    void RefreshMap()
    {

        if (LevelManager.Instance.map1_lvl2 = (PlayerPrefs.GetInt("map1_lvl2") != 0))
        {
            buttonlvl2.SetActive(true);
            buttonlvl2_lock.SetActive(false);
        }

        if (LevelManager.Instance.map1_lvl3 = (PlayerPrefs.GetInt("map1_lvl3") != 0))
        {
            buttonlvl3.SetActive(true);
            buttonlvl3_lock.SetActive(false);
        }

        if (LevelManager.Instance.map1_lvl4 = (PlayerPrefs.GetInt("map1_lvl4") != 0))
        {
            buttonlvl4.SetActive(true);
            buttonlvl4_lock.SetActive(false);
        }

        if (LevelManager.Instance.map1_lvl5 = (PlayerPrefs.GetInt("map1_lvl5") != 0))
        {
            buttonlvl5.SetActive(true);
            buttonlvl5_lock.SetActive(false);
        }

        if (LevelManager.Instance.map1_lvl6 = (PlayerPrefs.GetInt("map1_lvl6") != 0))
        {
            buttonlvl6.SetActive(true);
            buttonlvl6_lock.SetActive(false);
        }

        if (LevelManager.Instance.map1_lvl7 = (PlayerPrefs.GetInt("map1_lvl7") != 0))
        {
            buttonlvl7.SetActive(true);
            buttonlvl7_lock.SetActive(false);
        }

        if (LevelManager.Instance.map1_lvl8 = (PlayerPrefs.GetInt("map1_lvl8") != 0))
        {
            buttonlvl8.SetActive(true);
            buttonlvl8_lock.SetActive(false);
        }

        if (LevelManager.Instance.map1_lvl9 = (PlayerPrefs.GetInt("map1_lvl9") != 0))
        {
            buttonlvl9.SetActive(true);
            buttonlvl9_lock.SetActive(false);
        }

        if (LevelManager.Instance.map1_lvl10 = (PlayerPrefs.GetInt("map1_lvl10") != 0))
        {
            buttonlvl10.SetActive(true);
            buttonlvl10_lock.SetActive(false);
        }
    }
}
