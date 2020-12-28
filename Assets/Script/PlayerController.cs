using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController i;


    [Header("Artibut player")]
    public GameObject suntikanKanan;
    public GameObject suntikanKiri;
    public GameObject[] health;
    public int nyawa;
    public int peluru;
    public float speed;
    public int jumpForce;
    public int jumpCount;
    public int JumpValue; //Double Jump

    //
    private float horizontal;
    public float groundRadius = 1f;
    public LayerMask whatIsGround;
    public Transform groundCheck;


    [Header("Time Limit")]
    public GameObject TimePanel;
    public float TimeLimit;
    public GameObject textTimer;
    float Time_delay = 1f; // bunyi setiap 1 detik
    float stop_Time_Delay;

    [Header("Skor dan peluru")]
    public Text txt_skor;
    public Text txt_peluru;

    [Header("Handle Animasi")]
    public bool dead = false;
    public bool attack = false;
    public bool jump = false;
    public bool run = false;
    public bool facingRight = true;
    public bool grounded = false;

    //PANEL
    [Header("Panel Win dan Panel Failed")]
    public GameObject panelwin;
    public GameObject panelfailed;



    Rigidbody2D rb;
    Animator anim;


    float nextAttack;




    private void Awake()
    {
        SoundBG.Instance.stop();
        ScoreManager.i.ScoreAtLevel = 0;

        Time.timeScale = 1;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        i = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInputAndroid();

        txt_peluru.text = "X " + peluru.ToString();
        txt_skor.text = "Score : " + ScoreManager.i.ScoreAtLevel;
    }


    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);


        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");

        if (!dead && !attack)
        {
            anim.SetFloat("vSpeed", rb.velocity.y);
            anim.SetFloat("Speed", Mathf.Abs(horizontal));
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        if (horizontal > 0 && !facingRight && !dead && !attack)
        {
            Flip(horizontal);
        }

        else if (horizontal < 0 && facingRight && !dead && !attack)
        {
            Flip(horizontal);
        }
    }

    private void Flip(float horizontal)
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void HandleInputAndroid()
    {

        HandleAnimasi();

        if (CrossPlatformInputManager.GetButtonDown("jump") && !dead && jumpCount > 0)
        {
            AudioController.i.PlayAudio(1); // Suara Jump
            rb.velocity = Vector2.up * jumpForce;
            jumpCount--;
        }
        else if (CrossPlatformInputManager.GetButtonDown("attack") && !dead && Time.time > nextAttack && !run && !jump && peluru > 0)
        {
            nextAttack = Time.time + 0.5f;
            AudioController.i.PlayAudio(0); // Suara kunai
            attack = true;
            lemparSuntikan();
        }
        else
        {
            attack = false;
        }
    }

    private void HandleAnimasi()
    {
        if (rb.velocity.y != 0)
        {
            grounded = false;
            if (!grounded)
                anim.SetBool("Ground", !grounded);
        }
        else
        {
            grounded = true;
            if (grounded) { jumpCount = JumpValue; anim.SetBool("Ground", grounded); }
        }

        if (attack)
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }

        if(rb.velocity.x != 0)
        {
            run = true;
        }
        else
        {
            run = false;
        }

        if(rb.velocity.y != 0)
        {
            jump = true;
        }
        else
        {
            jump = false;
        }


        if (dead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void lemparSuntikan() 
    {
        if (facingRight)
        {
            Instantiate(suntikanKanan, transform.position, suntikanKanan.transform.rotation);
        }
        else
        {
            Instantiate(suntikanKiri, transform.position, suntikanKiri.transform.rotation);
        }
        peluru--;
        if (peluru <= 0)
        {
            peluru = 0;
        }
    }


    public void getCurNyawa()
    {
        if(nyawa == 2)
        {
            Destroy(health[0]);
        }
        else if(nyawa == 1)
        {
            Destroy(health[1]);
        }
        else if(nyawa <= 0)
        {
            Destroy(health[2]);
            dead = true;
            print("dead");
        }
    }

    private void blink()
    {
        StartCoroutine(Blink());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy" && Time.time > Time_delay)
        {
            Time_delay = Time.time + 1f;
            AudioController.i.PlayAudio(2);
            nyawa -= 1;
            getCurNyawa();
            blink();
            print("player kena enemy");
        }
    }

    private IEnumerator Blink()
    {
        yield return new WaitForSeconds(0f);
        anim.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 200);
        yield return new WaitForSeconds(0.1f);
        anim.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 200);
        yield return new WaitForSeconds(0.1f);
        anim.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 200);
        yield return new WaitForSeconds(0.1f);
        anim.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 200);
        yield return new WaitForSeconds(0.1f);
        anim.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 200);
        yield return new WaitForSeconds(0.1f);
        anim.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 200);
        yield return new WaitForSeconds(0.1f);
        anim.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 200);
        yield return new WaitForSeconds(0.1f);
        anim.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 200);
        yield return new WaitForSeconds(0.1f);
        anim.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 200);
        yield return new WaitForSeconds(0.1f);
        anim.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 200);
        yield return new WaitForSeconds(0.1f);
        anim.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 200);
        yield return new WaitForSeconds(0.1f);
        anim.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 200);
        yield return new WaitForSeconds(0.1f);
        anim.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 200);
        yield return new WaitForSeconds(0.1f);
        anim.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 200);
        yield return new WaitForSeconds(0.1f);
        anim.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 200);
        yield return new WaitForSeconds(0.1f);
        anim.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 200);
        yield return new WaitForSeconds(0.1f);
        anim.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 200);
        yield return new WaitForSeconds(0.1f);
        anim.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 200);
        yield return new WaitForSeconds(0.1f);
        anim.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 200);
        yield return new WaitForSeconds(0.1f);
        anim.GetComponent<SpriteRenderer>().color = Color.white;
    }

}
