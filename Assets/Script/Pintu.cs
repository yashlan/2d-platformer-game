using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pintu : MonoBehaviour
{
    public GameObject canvasSoal;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            canvasSoal.SetActive(true);
            Soal.i.getSoal();
        }
    }
}
