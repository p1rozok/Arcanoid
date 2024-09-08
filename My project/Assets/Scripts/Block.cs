

using UnityEngine;

public class Block : MonoBehaviour
{
    public int hitPoints = 1;
    public int points = 10;
    public GameObject powerUpPrefab;  // Префаб пауэр-апа (шарик)
    private GameManager gameManager;

    private void Start()
    {
        gameManager = Object.FindFirstObjectByType<GameManager>();

        gameManager.blocks.Add(this);

        Debug.Log("Block initialized: " + gameObject.name + " with hitPoints: " + hitPoints);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            hitPoints--;
            Debug.Log("Block hit: " + gameObject.name + ". Remaining hitPoints: " + hitPoints);

            if (hitPoints <= 0)
            {
                Debug.Log("Block destroyed: " + gameObject.name);
                gameManager.AddScore(points);

                // Спавним пауэр-ап с определённым шансом (например, 30%)
                if (Random.value > 0.7f)
                {
                    Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
                }

                gameManager.RemoveBlock(this);
                Destroy(gameObject);
            }
            else
            {
                ChangeBlockAppearance();
            }
        }
    }

    void ChangeBlockAppearance()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.color = Color.Lerp(renderer.color, Color.gray, 0.5f);
        Debug.Log("Block appearance changed: " + gameObject.name);
    }
}
