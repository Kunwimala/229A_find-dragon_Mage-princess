using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    public int damageAmount = 3;
    public float destroyDelay = 0.05f;

    private Vector2 direction;

    [SerializeField] private string targetTag;

    void Update()
    {
        transform.Translate(direction * speed *Time.deltaTime);
    }

    public void Setup(Vector2 direction)
    {
        this.direction = direction;
    }
/*private void TakeDamage(int damage)
    {
        Debug.Log("player tok" + damage + "damage!");
    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Player") || collision2D.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(damageAmount);
            Destroy(gameObject, destroyDelay);
            SceneManager.LoadScene("Lose");
        }

    }*/

    
}
