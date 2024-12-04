using UnityEngine;

public class BulletPoint : MonoBehaviour
{
    public int points = 1;  // Điểm cộng mỗi khi người chơi đi qua

    void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra nếu đối tượng là Player
        if (other.CompareTag("Player"))
        {
            // Cộng điểm khi người chơi chạm vào BulletPoint
            ScoreManager.Instance.AddPoints(points);

            // Xóa BulletPoint sau khi người chơi ăn
            Destroy(gameObject);
        }
    }
}
