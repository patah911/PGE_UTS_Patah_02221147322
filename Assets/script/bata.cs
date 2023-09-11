using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bata : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer { get; private set; }
    public Sprite[] states = new Sprite[0];
    public int health { get; private set; }
    public int points = 100;
    public bool unbreakable;

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Resetbata();
    }

    public void Resetbata()
    {
        gameObject.SetActive(true);

        if (!unbreakable)
        {
            health = states.Length;
            SpriteRenderer.sprite = states[health - 1];
        }
    }

    private void Hit()
    {
        if (unbreakable)
        {
            return;
        }

        health--;

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            SpriteRenderer.sprite = states[health - 1];
        }

        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            gameManager.Hit(this);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "bola"){
            Hit();
        }
    }

}