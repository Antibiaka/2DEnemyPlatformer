using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float  speed = 3f;
    bool limitR = true;
    float limit;
    private bool canTakeDamage = true;
    private void Start() {
        limit = transform.position.x;
    }
    void Update() {

        if (transform.position.x < (limit - 3f)) {
            limitR = true;
        }
        if (transform.position.x > (limit + 3f)) {
            limitR = false;
        }
        if (limitR) {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            transform.eulerAngles = new Vector3(0, 180, 0);

        } else {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.name == "Player") {
            if (canTakeDamage) {
                PlayerMovement.health -= 1;
                StartCoroutine(WaitForSeconds());
            }
            var player = collision.GetComponent<PlayerMovement>();
            player.knockbackCount = player.knockbackLength;
            if(collision.transform.position.x < transform.position.x) {
                player.enemyCheckR = true;
            } else {
                player.enemyCheckR = false;
            }
        }
    }
    IEnumerator WaitForSeconds() {
        canTakeDamage = false;
        yield return new WaitForSecondsRealtime(1);
        canTakeDamage = true;
    }


}
