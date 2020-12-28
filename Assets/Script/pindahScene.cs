using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pindahScene : MonoBehaviour
{


    public void pindahscene(string nama)
    {
        SceneManager.LoadScene(nama);
    }
}
