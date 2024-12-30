using UnityEngine;

public class BulletPoint : MonoBehaviour
{
    public int points = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra nếu đối tượng là Player
        if (other.CompareTag("Player"))
        {
            // Chỉ tính điểm nếu Player còn sống
            Player player = other.GetComponent<Player>();
            if (player != null && player.enabled) // Kiểm tra Player còn active không
            {
                // Cộng điểm khi player chạm vào BulletPoint
                if (ScoreManager.Instance != null)
                {
                    ScoreManager.Instance.AddPoints(points);
                    Debug.Log($"Added {points} points. Current score: {ScoreManager.Instance.GetCurrentScore()}");
                }
                else
                {
                    Debug.LogError("ScoreManager Instance is null!");
                }
            }

            // Xóa BulletPoint sau khi người chơi ăn
            Destroy(gameObject);
        }
    }
}