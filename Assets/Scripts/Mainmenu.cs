using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Health healthScript;
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");

    }

     
    public void QuitGame()
    {

        Application.Quit();
    }


}
