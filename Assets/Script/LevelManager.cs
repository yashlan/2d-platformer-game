using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public string map1lvl2 = "";
    public string map1lvl3 = "";
    public string map1lvl4 = "";
    public string map1lvl5 = "";
    public string map1lvl6 = "";
    public string map1lvl7 = "";
    public string map1lvl8 = "";
    public string map1lvl9 = "";
    public string map1lvl10 = "";

    [Header("Level Map 1")]
    public bool map1_lvl2 = false;
    public bool map1_lvl3 = false;
    public bool map1_lvl4 = false;
    public bool map1_lvl5 = false;
    public bool map1_lvl6 = false;
    public bool map1_lvl7 = false;
    public bool map1_lvl8 = false;
    public bool map1_lvl9 = false;
    public bool map1_lvl10 = false;





    private void Awake()
    {
        if (instance != null && instance != this)
        {

            Destroy(this.gameObject);
            return;
        }

        else
        {
            DontDestroyOnLoad(transform.gameObject);
            instance = this;
        }
    }

    private static LevelManager instance = null;
    public static LevelManager Instance
    {
        get { return instance; }
    }


    // Start is called before the first frame update
    void Start()
    {
        LoadMap1();
    }

    private void Update()
    {
        UnlockNewLevel();
    }

    void LoadMap1()
    {
        //Map 1
        map1_lvl2 = (PlayerPrefs.GetInt("map1_lvl2") != 0);
        map1_lvl3 = (PlayerPrefs.GetInt("map1_lvl3") != 0);
        map1_lvl4 = (PlayerPrefs.GetInt("map1_lvl4") != 0);
        map1_lvl5 = (PlayerPrefs.GetInt("map1_lvl5") != 0);
        map1_lvl6 = (PlayerPrefs.GetInt("map1_lvl6") != 0);
        map1_lvl7 = (PlayerPrefs.GetInt("map1_lvl7") != 0);
        map1_lvl8 = (PlayerPrefs.GetInt("map1_lvl8") != 0);
        map1_lvl9 = (PlayerPrefs.GetInt("map1_lvl9") != 0);
        map1_lvl10 = (PlayerPrefs.GetInt("map1_lvl10") != 0);

    }

    private void UnlockNewLevel()
    {
        if (map1lvl2 == "unlocked")
        {
            PlayerPrefs.SetInt("map1_lvl2", (map1_lvl2 ? 1 : 1));
        }

        if (map1lvl3 == "unlocked")
        {
            PlayerPrefs.SetInt("map1_lvl3", (map1_lvl3 ? 1 : 1));
        }

        if (map1lvl4 == "unlocked")
        {
            PlayerPrefs.SetInt("map1_lvl4", (map1_lvl4 ? 1 : 1));
        }

        if (map1lvl5 == "unlocked")
        {
            PlayerPrefs.SetInt("map1_lvl5", (map1_lvl5 ? 1 : 1));
        }

        if (map1lvl6 == "unlocked")
        {
            PlayerPrefs.SetInt("map1_lvl6", (map1_lvl6 ? 1 : 1));
        }

        if (map1lvl7 == "unlocked")
        {
            PlayerPrefs.SetInt("map1_lvl7", (map1_lvl7 ? 1 : 1));
        }

        if (map1lvl8 == "unlocked")
        {
            PlayerPrefs.SetInt("map1_lvl8", (map1_lvl8 ? 1 : 1));
        }

        if (map1lvl9 == "unlocked")
        {
            PlayerPrefs.SetInt("map1_lvl9", (map1_lvl9 ? 1 : 1));
        }

        if (map1lvl10 == "unlocked")
        {
            PlayerPrefs.SetInt("map1_lvl10", (map1_lvl10 ? 1 : 1));
        }
    }

    public void ChangeStringMap()
    {
        if(SceneManager.GetSceneByName("level 1").isLoaded)
        {
            map1lvl2 = "unlocked";
        }

        if (SceneManager.GetSceneByName("level 2").isLoaded)
        {
            map1lvl3 = "unlocked";
        }

        if (SceneManager.GetSceneByName("level 3").isLoaded)
        {
            map1lvl4 = "unlocked";
        }

        if (SceneManager.GetSceneByName("level 4").isLoaded)
        {
            map1lvl5 = "unlocked";
        }

        if (SceneManager.GetSceneByName("level 5").isLoaded)
        {
            map1lvl6 = "unlocked";
        }

        if (SceneManager.GetSceneByName("level 6").isLoaded)
        {
            map1lvl7 = "unlocked";
        }

        if (SceneManager.GetSceneByName("level 7").isLoaded)
        {
            map1lvl8 = "unlocked";
        }

        if (SceneManager.GetSceneByName("level 8").isLoaded)
        {
            map1lvl9 = "unlocked";
        }

        if (SceneManager.GetSceneByName("level 9").isLoaded)
        {
            map1lvl10 = "unlocked";
        }

    }
}
