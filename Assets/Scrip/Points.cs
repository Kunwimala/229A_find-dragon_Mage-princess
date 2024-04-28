using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    private int points = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Points"))
        {
            points++;
            UpdatePointsText();
            Destroy(other.gameObject);
        }
    }

    private void UpdatePointsText()
    {
        pointsText.text = "Points: " + points.ToString();
    }
}