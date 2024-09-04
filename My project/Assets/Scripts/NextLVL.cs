
using UnityEngine;
using UnityEngine.UI;

public class NextLevelButton : MonoBehaviour
{
    private GameManager gameManager;
    public Button nextLevelButton; // ������ �� ������

    void Start()
    {
        // ������� ������ GameManager
        gameManager = Object.FindFirstObjectByType<GameManager>();

        // ����������� ����� NextLevel() � ������
        nextLevelButton.onClick.AddListener(OnNextLevelButtonClick);
    }

    void OnNextLevelButtonClick()
    {
        // �������� ����� ��� �������� �� ��������� �������
        gameManager.NextLevel();
    }
}
