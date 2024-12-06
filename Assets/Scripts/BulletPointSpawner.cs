using UnityEngine;

public class BulletPointSpawner : MonoBehaviour
{
    public GameObject bulletPointPrefab;  // Prefab của BulletPoint
    public float spawnOffsetY = 5f;       // Khoảng cách từ quả bóng tới BulletPoint
    public float spawnInterval = 10f;      // Thời gian giữa mỗi lần spawn
    public float spawnRangeX = 8f;        // Phạm vi trên trục X để spawn BulletPoint

    private float lastSpawnTime;          // Thời gian cuối cùng spawn BulletPoint
    public GameObject player;             // Tham chiếu đến Player (quả bóng)

    void Update()
    {
        // Kiểm tra thời gian để spawn BulletPoint theo spawnInterval
        if (Time.time - lastSpawnTime > spawnInterval)
        {
            SpawnBulletPoint();
            lastSpawnTime = Time.time;
        }
    }

    // Hàm spawn BulletPoint
    void SpawnBulletPoint()
    {
        if (player != null)
        {
            // Lấy vị trí của Player
            Vector3 playerPosition = player.transform.position;

            // Tạo vị trí của BulletPoint trên quả bóng (player), thêm offset theo trục Y
            Vector3 spawnPosition = new Vector3(playerPosition.x, playerPosition.y + spawnOffsetY, playerPosition.z);

            // Sinh ra BulletPoint tại vị trí spawn
            Instantiate(bulletPointPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
