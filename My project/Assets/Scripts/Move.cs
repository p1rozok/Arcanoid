using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f;
    public float minX, maxX;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 newPosition = transform.position + Vector3.right * horizontalInput * speed * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);  
        transform.position = newPosition;
    }
}
