using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemyCanon : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    private Rigidbody2D rb;

    float fireRate,  nextFire;
  
    [HideInInspector]
    public static bool isShootingEnabled;
    // Start is called before the first frame update
    void Start()
    {

        fireRate = 2f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTimeToShoot();
    }
    void CheckTimeToShoot() {
        if (Time.time > nextFire && isShootingEnabled) {
     
            Instantiate(bullet, transform.position, Quaternion.Euler(0,0,90));

            nextFire = Time.time + fireRate;
        }
    }
   
    private void OnTriggerStay2D(Collider2D col) {
        if (col.gameObject.name.Equals("Player")){
            isShootingEnabled = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.name.Equals("Player")) {
            isShootingEnabled = false;
        }

    }
}
