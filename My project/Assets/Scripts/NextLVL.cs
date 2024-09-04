
using UnityEngine;
using UnityEngine.UI;

public class NextLevelButton : MonoBehaviour
{
    private GameManager gameManager;
    public Button nextLevelButton; // Ссылка на кнопку

    void Start()
    {
        // Находим объект GameManager
        gameManager = Object.FindFirstObjectByType<GameManager>();

        // Привязываем метод NextLevel() к кнопке
        nextLevelButton.onClick.AddListener(OnNextLevelButtonClick);
    }

    void OnNextLevelButtonClick()
    {
        // Вызываем метод для перехода на следующий уровень
        gameManager.NextLevel();
    }
}
