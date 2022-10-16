using UnityEngine;
using UnityEngine.SceneManagement;

public class menuControl : MonoBehaviour
{
    public void GameRestart()
    {
       SceneManager.LoadScene("level1"); 
    }

    public void Quit()
    {
        Application.Quit(); //only compiled version
    }
}
