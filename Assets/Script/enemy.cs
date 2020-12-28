using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public static enemy i;

    [Header("Gerak Enemy(pilih satu)")]
    public bool atasBawah;
    public bool kiriKanan;

    [Header("partoli")]
    public float batasKanan;
    public float batasKiri;
    public float batasAtas;
    public float batasBawah;

    [Header("Artibute")]
    public float speed;
    public GameObject efekDeath;
    public bool moveRight;
    public bool moveTop;
    private float localScaleX;
    private float localScaleY;




    float Time_delay;




    private void Awake()
    {
        i = this;

        if(batasKanan != 0 && batasKiri != 0)
        {
            kiriKanan = true;
        }
        else if(batasAtas != 0 && batasBawah != 0)
        {
            atasBawah = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        localScaleX = transform.localScale.x;
        localScaleY = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (kiriKanan) //gerak kanan kiri
        {
            if (transform.localPosition.x > batasKanan)
            {
                moveRight = false;
            }
            else if (transform.localPosition.x < batasKiri)
            {
                moveRight = true;
            }

            if (moveRight)
            {
                transform.Translate(2 * Time.deltaTime * speed, 0, 0);
                transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                moveRight = false;
                transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
                transform.localScale = new Vector3(-localScaleX, transform.localScale.y, transform.localScale.z);

            }
        }

        if (atasBawah) //gerak atas bawah
        {
            if (transform.localPosition.y > batasAtas)
            {
                moveTop = false;
            }
            else if (transform.localPosition.y < batasBawah)
            {
                moveTop = true;
            }

            if (moveTop)
            {
                transform.Translate(0, 2 * Time.deltaTime * speed, 0);
                transform.localScale = new Vector3(transform.localScale.x,localScaleY, transform.localScale.z);
            }
            else
            {
                moveTop = false;
                transform.Translate(0, -2 * Time.deltaTime * speed, 0);
                transform.localScale = new Vector3(transform.localScale.x, localScaleY, transform.localScale.z);

            }
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "weapon")
        {
            Destroy(gameObject);
            Instantiate(efekDeath, transform.position, Quaternion.identity);
            print("test");
        }
    }

    private void OnDestroy()
    {
        ScoreManager.i.ScoreAtLevel += 20;
    }
}
