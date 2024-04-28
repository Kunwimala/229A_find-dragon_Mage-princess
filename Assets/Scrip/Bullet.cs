using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    
    
    public int damageAmount = 3;
    public float destroyDelay = 0.05f;
    

    void TakeDamage(int damage)
    {
        Debug.Log("player tok" + damage + "damage!");
    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Player") || collision2D.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(damageAmount);
            Destroy(gameObject , destroyDelay);
            SceneManager.LoadScene("Lose");
        }
    }
}
