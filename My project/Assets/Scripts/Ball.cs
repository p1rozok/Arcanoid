
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float initialSpeed = 10f;
    private Rigidbody2D rb;
    private bool isLaunched = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on ball!");
        }

        rb.isKinematic = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isLaunched)
        {
            LaunchBall();
        }
    }

    void LaunchBall()
    {
        isLaunched = true;
        rb.isKinematic = false;
        rb.velocity = new Vector2(1, 1).normalized * initialSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);

        // ѕроверка на наличие коллайдера и тега "Paddle"
        if (collision.collider != null && collision.gameObject.CompareTag("Paddle"))
        {
            Debug.Log("Collision with paddle!");

            float hitFactor = (transform.position.x - collision.transform.position.x) / collision.collider.bounds.size.x;

            Vector2 direction = new Vector2(hitFactor, 1).normalized;
            rb.velocity = direction * rb.velocity.magnitude;
        }
        else
        {
            Debug.LogWarning("Collision occurred, but no paddle detected or no collider found.");
        }
    }
}
