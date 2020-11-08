using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
    public float speed = 5;
    public float jumpForce = 1000;
    public float dashPower = 150;

    [HideInInspector]
    public static Rigidbody2D rb;
    private GameObject gameObj;

    private bool isGrounded;

    //Dash part
    private bool isDashing;
    private bool canDashing = true;
    IEnumerator dashCoroutine;
    float direction, normalGravity;

    //particles effect system
    public ParticleSystem Particles;


    //colectable
    [HideInInspector]
    public static bool isGuntaken = false;

    //health system
    [HideInInspector]
    public static int health;
    public GameObject health1, health2, health3,gunTaken;

    //knockback from enemy
    public float knockback = 5f;
    public float knockbackLength = 0.7f;
    public float knockbackCount;
    public bool enemyCheckR;



    void Start() {
        HealthSetup();
        rb = GetComponent<Rigidbody2D>();
        normalGravity = rb.gravityScale;
        gunTaken.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update() {
       // Debug.Log(health);
        BaseMovement();
        HealthCheck();

        if (isGuntaken) {
            gunTaken.gameObject.SetActive(true);
        }
    }

    void FixedUpdate() {

        if (isDashing) {
            rb.AddForce(new Vector2(direction * dashPower, 0), ForceMode2D.Impulse);
            //CreateParticles();
        }

    }


    void BaseMovement() {

        float xDisplacement = Input.GetAxis("Horizontal") * speed;

        //enemyknockback
        if (knockbackCount <= 0) {
            rb.velocity = new Vector2(xDisplacement, rb.velocity.y);
        } else {
            if (enemyCheckR) 
                rb.velocity = new Vector2(-knockback, knockback);
            if (!enemyCheckR) 
                rb.velocity = new Vector2(knockback, knockback);
            knockbackCount -= Time.deltaTime;
            }

        if (xDisplacement > 0) {
            transform.eulerAngles = new Vector3(0, 180, 0);
        } else if (xDisplacement < 0) {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) //jump and test @on ground@
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded) {
            xDisplacement = Input.GetAxis("Horizontal") * speed * 3;  //SHIFT  mode activated
            rb.velocity = new Vector2(xDisplacement, rb.velocity.y);
        }

       

        //dash stuff 1st check on direction
        float horisontal = Input.GetAxis("Horizontal");

        if (horisontal != 0) {
            direction = horisontal;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && canDashing == true) {

            if (dashCoroutine != null) {
                StopCoroutine(dashCoroutine);
            }

            dashCoroutine = Dash(.1f, 1);
            StartCoroutine(dashCoroutine);
        }
    }

    void OnCollisionEnter2D(Collision2D col) {

        if (col.transform.tag == "Gun") {
            isGuntaken = true;
            Destroy(col.gameObject);
        }

        if (col.transform.tag == "Ground") {
            isGrounded = true;
        }

        if (col.transform.tag == "MovingGround" ) {
            isGrounded = true;
            this.transform.parent = col.transform;
        }
        


    }

    void OnCollisionExit2D(Collision2D col) {

        if (col.transform.tag == "MovingGround") {
            this.transform.parent = null;
        }

    }



    IEnumerator Dash(float dashDuration, float dashCd) {
        Vector2 originalVelocity = rb.velocity;
        isDashing = true;
        canDashing = false;
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;

        yield return new WaitForSeconds(dashDuration);

        isDashing = false;
        rb.gravityScale = normalGravity;
        rb.velocity = originalVelocity;

        yield return new WaitForSeconds(dashCd);

        canDashing = true;

    }

    //void CreateParticles()
    //{
    //    Particles.Play();    //particles effect system
    //}
    void HealthSetup() {
        health = 3;
        health1.gameObject.SetActive(true);
        health2.gameObject.SetActive(true);
        health3.gameObject.SetActive(true);
    }
    void HealthCheck() {
        switch (health) {
            case 3:
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(true);
                health3.gameObject.SetActive(true);
                break;
            case 2:
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(true);
                health3.gameObject.SetActive(false);
                break;
            case 1:
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(false);
                health3.gameObject.SetActive(false);
                break;
            case 0:
                health1.gameObject.SetActive(false);
                health2.gameObject.SetActive(false);
                health3.gameObject.SetActive(false);
                break;

        }

        if (health < 1) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    void KnockBack() {
       
    }
}
