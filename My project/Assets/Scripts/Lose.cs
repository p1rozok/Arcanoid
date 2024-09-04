
using UnityEngine;

public class BallOutTrigger : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); 

        if (gameManager == null)
        {
            Debug.LogError("GameManager �� ������! ���������, ��� ������ � ����������� GameManager ���������� �� �����.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Destroy(other.gameObject); 

            if (gameManager != null)
            {
                gameManager.LoseLife(); 
            }
        }
    }
}
