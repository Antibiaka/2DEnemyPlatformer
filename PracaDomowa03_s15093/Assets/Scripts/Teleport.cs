using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    private int nextScene;
    public new SpriteRenderer renderer;
    public BoxCollider2D boxCollider;

    private void Start()
    {
       
        renderer.enabled = false;
        boxCollider.enabled = false;
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void Update() {
        if (PlayerMovement.isGuntaken) {
            renderer.enabled = true;
            boxCollider.enabled = true;
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        SceneManager.LoadScene(nextScene);
    }
}
