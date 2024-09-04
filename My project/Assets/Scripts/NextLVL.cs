
using UnityEngine;
using UnityEngine.UI;

public class NextLevelButton : MonoBehaviour
{
    private GameManager gameManager;
    public Button nextLevelButton;

    void Start()
    {
       
        gameManager = Object.FindFirstObjectByType<GameManager>();

        
        nextLevelButton.onClick.AddListener(OnNextLevelButtonClick);
    }

    void OnNextLevelButtonClick()
    {
        
        gameManager.NextLevel();
    }
}
