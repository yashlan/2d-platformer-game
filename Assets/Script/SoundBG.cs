using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundBG : MonoBehaviour
{
    public AudioSource bgMusik;


    // Use this for initialization
    private void Start()
    {
        bgMusik = GetComponent<AudioSource>();
        bgMusik.Play();

    }

    private static SoundBG instance = null;
    public static SoundBG Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            Destroy(this.bgMusik);
            return;
        }

        else
        {
            DontDestroyOnLoad(transform.gameObject);
            instance = this;
        }

        //setting agar gameobjek tidak dihancurkan saat reload Scene
        DontDestroyOnLoad(this.bgMusik);

    }

    public void stop()
    {
        bgMusik.Stop();
    }
}
