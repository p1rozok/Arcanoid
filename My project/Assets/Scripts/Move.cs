using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f;
    public float minX, maxX;  

    private bool isUsingMouse = false; 

    void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            isUsingMouse = false; 
            Vector3 newPosition = transform.position + Vector3.right * horizontalInput * speed * Time.deltaTime;
            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX); 
            transform.position = newPosition;
        }
        else if (Input.GetMouseButton(0) || Input.GetAxis("Mouse X") != 0)
        {

            isUsingMouse = true; 
            float mouseX = Input.mousePosition.x;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, 0, Camera.main.nearClipPlane));
            Vector3 newPosition = transform.position;
            newPosition.x = Mathf.Clamp(mouseWorldPosition.x, minX, maxX); 
            transform.position = newPosition;
        }
    }
}
