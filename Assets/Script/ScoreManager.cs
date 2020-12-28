using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int ScoreAtLevel;
    public int CurrentScore;




    private static ScoreManager instance = null;
    public static ScoreManager i
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (i != null && i != this)
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
    // Start is called before the first frame update
    void Start()
    {
        //LOAD SCORE
        ScoreAtLevel = PlayerPrefs.GetInt("ScoreAtLevel", ScoreAtLevel);
        CurrentScore = PlayerPrefs.GetInt("CurrentScore", CurrentScore);
    
    }

    // Update is called once per frame
    void Update()
    {

        //SAVE SCORE TERBARU
        PlayerPrefs.SetInt("ScoreAtLevel", ScoreAtLevel);
        PlayerPrefs.SetInt("CurrentScore", CurrentScore);
    }

    public void Save()
    {
        CurrentScore += ScoreAtLevel;
    }

}
