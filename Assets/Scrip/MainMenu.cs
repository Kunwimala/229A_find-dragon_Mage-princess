using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  
    public void Game()
    {
        SceneManager.LoadScene("Game");
        
        
    }
    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }
    public void End()
    {
        Application.Quit();
        
    }
    public void MM()
    {
        SceneManager.LoadScene("Mainmenu");
    }
    
}
