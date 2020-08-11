using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float maxSpeed;
    Rigidbody2D myRD;
    Animator myAnime;
    bool facingRight;
    public ParticleSystem dust;

    //Jumping variables
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    

    //Shooting variables
    public Transform gunTip;
    public GameObject bullet;
    float fireRate = 0.5f;
    float nextFire = 0f;


    //Attack
    bool isAttacked = true;

    //Level
    public Level level;
    [SerializeField]
    TextMeshProUGUI currentLevelText;



    // Start is called before the first frame update
    void Start()
    {
        myRD = GetComponent<Rigidbody2D>();
        myAnime = GetComponent<Animator>();
        
        facingRight = true;

        level = new Level(1, OnLevelUp);


    }

    public void OnLevelUp()
    {
        print("I level Up");
    }

    // Update is called once per frame

    void Update()
    {
        if (grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnime.SetBool("isGrounded", grounded);
            myRD.AddForce(new Vector2(0, jumpHeight));
            createDust();

        }

        //check player shooting
        if (Input.GetAxisRaw("Fire1") > 0)
        {
            
            myAnime.SetBool("isAttacked", isAttacked);
            fireRocket();
            
        }else 
        {
            myAnime.SetBool("isAttacked", false);
        }

        if (Input.GetAxisRaw("Fire1") > 0)
        {
            level.AddExp(1);
            currentLevelText.text = level.currentLevel.ToString();
        }
    }
    void FixedUpdate()
    {

        // check if we are grounded = if no, we are falling
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnime.SetBool("isGrounded", grounded);

        myAnime.SetFloat("verticalSpeed", myRD.velocity.y);

        float move = Input.GetAxis("Horizontal");
        myAnime.SetFloat("speed", Mathf.Abs(move));
        myRD.velocity = new Vector2(move * maxSpeed, myRD.velocity.y);

        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }

    }

    void flip()
    {
        createDust();
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

     void createDust()
    {
        dust.Play();
    }

    void fireRocket()
    {
       

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }else if (!facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0,180f)));
            }
        }
    }
}
