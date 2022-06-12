using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public weaponControl weapon;
    public string sceneVictoria;
    public string sceneDerrota;
    private int item = 0;
    public int maxHealth = 5;
    public int currentHealth;
    //public HealthBar healthBar;
    [SerializeField] private Text ItemText;

    Vector2 moveDirection;
    Vector2 mousePosition;

    void Start()
    {
        currentHealth = maxHealth;
        // healthBar.SetMaxHealth(maxHealth);
    }
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            item++;
            ItemText.text = "Item: " + item;

            if (item == 5) { SceneManager.LoadScene(sceneVictoria); }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            TakeDamage(1);
            if (currentHealth == 0) { SceneManager.LoadScene(sceneDerrota); }
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // healthBar.SetHealth(currentHealth);
    }
}
