using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    bool canTakeDamage = true;

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            if (canTakeDamage) {
                StartCoroutine(WaitForSeconds());
                PlayerMovement.health -= 1;
            }
            
        }
    }
    IEnumerator WaitForSeconds() {
        canTakeDamage = false;
        yield return new WaitForSecondsRealtime(3);
        canTakeDamage = true;
    }

}
