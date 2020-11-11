using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyComet : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player1") || collision.gameObject.CompareTag("player2") || collision.gameObject.CompareTag("planet"))
        {
            Destroy(gameObject);
        }
    }
}
