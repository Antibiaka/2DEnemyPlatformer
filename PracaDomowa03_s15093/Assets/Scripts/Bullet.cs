using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Security.Cryptography;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour {
    private Transform targetPlayer;
    private Rigidbody2D rb;

    PlayerMovement target;
    Vector2 moveDirection;
    float moveSpeed = 7f;
    float rotateSpeed = 400f;




    // Start is called before the first frame update
    void Start() {

        targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
      

        //target = GameObject.FindObjectOfType<PlayerMovement>();
        //moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        //rb.velocity = new Vector2(moveDirection.x, moveDirection.y);

        Destroy(gameObject, 3f);



    }

    private void FixedUpdate() {
        Vector2 direction = (Vector2)targetPlayer.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity =-rotateAmount*rotateSpeed;

        rb.velocity = transform.up * moveSpeed;
    }


    private void OnTriggerEnter2D(Collider2D col) {

        if (col.gameObject.name.Equals("Player")) {
            PlayerMovement.health -= 1;
            Destroy(gameObject);
        }
        if (col.gameObject.tag.Equals("Ground") || col.gameObject.tag.Equals("Ladder")) {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
