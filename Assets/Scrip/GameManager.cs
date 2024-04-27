using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text applepoints;
    private static GameManager _instance;
    
    public static GameManager Instance
    {
        get { return _instance; }
    }
     int ApplePoints;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void AddScore(int Points)
    {
        ApplePoints += Points;
        UpdatePointText();
    }

    public void ResetScore()
    {
        ApplePoints = 0;
        UpdatePointText();
    }

    private void UpdatePointText()
    {
       applepoints.text = $"Points : {ApplePoints}";
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Lose");
    }
}

