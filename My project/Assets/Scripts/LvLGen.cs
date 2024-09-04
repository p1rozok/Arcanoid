
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] blockPrefabs;
    public int rows = 5;
    public float blockWidth = 1f;
    public float blockHeight = 0.5f;
    public float spacing = 0.1f;
    public float screenPadding = 0.5f;

    void Start()
    {
        GenerateLevel();
    }

    public void GenerateLevel() 
    {
        Camera mainCamera = Camera.main;
        Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

        float screenWidth = topRight.x - bottomLeft.x - 2 * screenPadding;
        float screenHeight = topRight.y - bottomLeft.y - 2 * screenPadding;

        int columns = Mathf.FloorToInt(screenWidth / (blockWidth + spacing));

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                GameObject blockPrefab = blockPrefabs[Random.Range(0, blockPrefabs.Length)];

                float xPos = bottomLeft.x + screenPadding + (blockWidth + spacing) * col + blockWidth / 2f;
                float yPos = topRight.y - screenPadding - (blockHeight + spacing) * row - blockHeight / 2f;

                Instantiate(blockPrefab, new Vector2(xPos, yPos), Quaternion.identity, transform);
            }
        }
    }
}
