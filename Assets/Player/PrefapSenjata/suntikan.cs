using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suntikan : MonoBehaviour
{
    public float timeDestroy;
    public int speed;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    private void Start()
    {
        Destroy(gameObject, timeDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, 0);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }
}
