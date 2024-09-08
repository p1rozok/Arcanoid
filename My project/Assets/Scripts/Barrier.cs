using UnityEngine;

public class Barrier : MonoBehaviour
{
    public float activeTime = 5f;  

    void Start()
    {
        gameObject.SetActive(false);  
    }

    
    public void Activate()
    {
        gameObject.SetActive(true);
        Invoke("Deactivate", activeTime);  
    }

    
    void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
          
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 bounce = new Vector2(rb.velocity.x, Mathf.Abs(rb.velocity.y)); 
                rb.velocity = bounce;
            }
        }
    }
}
