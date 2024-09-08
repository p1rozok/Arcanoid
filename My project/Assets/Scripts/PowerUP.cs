using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float fallSpeed = 2f;

    void Update()
    {
        // Пауэр-ап падает вниз
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Paddle"))
        {
            // При сборе активируем барьер через GameManager
            GameManager.Instance.ActivateBarrier();
            Destroy(gameObject);  // Уничтожаем пауэр-ап
        }
    }
}
