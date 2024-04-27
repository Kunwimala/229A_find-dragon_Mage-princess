using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
   private int score = 0;
   [SerializeField] private TextMeshProUGUI points;

    void OnTriggerEnter2D(Collider2D other)
   {
      if ( other.CompareTag("Player"))
      {
         if (gameObject.CompareTag("Points"))
         {
            score += 1;
            points.text = "Points:" + score;
            
            Debug.Log("player:" + score);
            
            Destroy(gameObject);
         }
      }
   }
}
