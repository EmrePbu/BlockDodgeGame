using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroyer : MonoBehaviour
{
    // on collision enter 2d destroyer collisons game object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // destroy the game object with tag Block
        FindObjectOfType<GameManager>().AddScore(0.25f);
        // destrot the collision game object
        Destroy(collision.gameObject);
    }
}
