using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
   
    public string gameSceneName = "SampleScene"; 

 
    public void StartGame()
    {
        Time.timeScale = 1f;  
        SceneManager.LoadScene(gameSceneName); 
        gameObject.SetActive(false);
    }
}
