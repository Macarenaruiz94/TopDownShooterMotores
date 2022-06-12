using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemigoControl : MonoBehaviour
{
    public Transform player;
    private int Health = 2;
    public float speed;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime); 
    }
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
