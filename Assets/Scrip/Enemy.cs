using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int damageAmount = 3;
    public float destroyDelay = 0.05f;

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Player") || collision2D.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(damageAmount);
            Destroy(gameObject , destroyDelay);
            SceneManager.LoadScene("Lose");
        }
    }

    void TakeDamage(int damage)
    {
        Debug.Log("player tok" + damage + "damage!");
    }
}
