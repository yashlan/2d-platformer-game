using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject panel;

    // Update is called once per frame
    void Update()
    {
        if (panel.activeSelf)
        {
            pause();
        }
    }

    public void pause()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
    }

    public void resume()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void exitGame()
    {
        SceneManager.LoadScene("bermain");
    }
}
