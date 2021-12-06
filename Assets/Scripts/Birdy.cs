using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birdy : MonoBehaviour
{
    public float velocity = 1f;
    public Rigidbody2D rb2D;

    public bool isDead;

    public GameManager managerGame;
    public GameObject DeathScreen;

    private void Start()
    {
        Time.timeScale = 1;
        rb2D.velocity = Vector2.up * velocity * 2;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rb2D.velocity = Vector2.up * velocity;
        }
        if(rb2D.transform.position.y > 1.2f)
        {
            deathAction();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name=="ScoreArea")
        {
            managerGame.UpdateScore();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="DeathArea")
        {
            deathAction();
        }
    }

    private void deathAction()
    {
        isDead = true;
        Time.timeScale = 0;

        DeathScreen.SetActive(true);
    }
}
