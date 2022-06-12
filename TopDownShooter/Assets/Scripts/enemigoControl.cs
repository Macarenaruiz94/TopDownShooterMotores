using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigoControl : MonoBehaviour
{
    private int Health = 2;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bala"))
        {
            Health -= 1;

            if (Health == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
