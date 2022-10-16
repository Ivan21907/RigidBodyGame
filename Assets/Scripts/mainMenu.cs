using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void LoadScene1()
    {
       SceneManager.LoadScene("level1"); 
    }

    public void LoadScene2()
    {
       SceneManager.LoadScene("level2"); 
    }

    public void Quit()
    {
        Application.Quit(); //only compiled version
    }
}
