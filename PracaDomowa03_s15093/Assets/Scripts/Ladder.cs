using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {
    // Start is called before the first frame update
    public float speed = 6;
    
    void Start() {
        
        
    }

    // Update is called once per frame
    void Update() {
    }
   
    void OnTriggerStay2D(Collider2D col) {
        if (col.tag == "Player" && Input.GetKey(KeyCode.W)) {
            col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        } else if (col.tag == "Player" && Input.GetKey(KeyCode.S)) {
            col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
        } else {
            col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            col.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D col) {
        col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        col.GetComponent<Rigidbody2D>().gravityScale = 1.3f;
    }

}
