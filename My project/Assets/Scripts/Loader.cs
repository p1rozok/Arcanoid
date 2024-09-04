using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameOverScene()
    {
        
        SceneManager.LoadScene("GameOverScene");
    }

    public void LoadMainMenu()
    {
      
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
       
        Application.Quit();
    }

    public void RestartGame()
    {
      
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;  
    }
}
