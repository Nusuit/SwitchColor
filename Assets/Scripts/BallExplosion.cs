using UnityEngine;

public class BallExplosion : MonoBehaviour
{
    public GameObject explosionPrefab;  // Prefab của bóng nổ (lựu đạn)

    // Sự kiện va chạm với một đối tượng
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Tạo bóng nổ từ Prefab khi va chạm
        CreateExplosion(collision.contacts[0].point);
    }

    // Hàm tạo bóng nổ tại vị trí va chạm
    void CreateExplosion(Vector2 position)
    {
        // Khởi tạo Prefab tại vị trí va chạm
        Instantiate(explosionPrefab, position, Quaternion.identity);
    }
}
