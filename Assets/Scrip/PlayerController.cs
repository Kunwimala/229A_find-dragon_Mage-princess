using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    private void Start()
    {
         gameManager = GameObject.FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Points"))
        {
            gameManager.AddScore(1);
            Destroy(other.gameObject);
        }
    }

    private void Die()
    {
        gameManager.ResetScore();
        gameManager.GameOver();
    }
    }

