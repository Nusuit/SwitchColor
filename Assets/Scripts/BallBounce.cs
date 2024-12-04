using UnityEngine;

public class UIBallBounce : MonoBehaviour
{
    public float bounceHeight = 30f;    // Chiều cao tối đa của cú nảy
    public float bounceSpeed = 2f;      // Tốc độ nảy (ảnh hưởng đến tốc độ di chuyển lên xuống)
    public float gravity = -9.8f;       // Trọng lực để làm bóng rơi xuống
    public float damping = 0.8f;        // Hệ số giảm dần khi nảy (quán tính)

    private RectTransform rectTransform;
    private Vector2 originalPosition;
    private float velocityY = 0f;       // Tốc độ di chuyển theo trục Y (yOffset)

    void Start()
    {
        // Lấy RectTransform của đối tượng UI để điều khiển vị trí
        rectTransform = GetComponent<RectTransform>();

        // Lưu vị trí gốc của đối tượng UI
        originalPosition = rectTransform.anchoredPosition;
    }

    void Update()
    {
        // Thêm trọng lực vào tốc độ
        velocityY += gravity * Time.deltaTime;  // Tính tốc độ rơi theo trọng lực

        // Tính toán sự nảy lên
        float bounce = Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;

        // Cập nhật tốc độ và vị trí Y của đối tượng UI (nảy lên rồi rơi xuống)
        velocityY = velocityY * damping;   // Giảm dần tốc độ sau mỗi lần nảy

        // Cập nhật vị trí Y của bóng
        rectTransform.anchoredPosition = new Vector2(originalPosition.x, originalPosition.y + bounce + velocityY);

        // Nếu bóng chạm đất (hoặc gần với vị trí gốc), thì khởi động lại với tốc độ nhỏ hơn
        if (Mathf.Abs(velocityY) < 0.1f && rectTransform.anchoredPosition.y <= originalPosition.y)
        {
            velocityY = 0f; // Đặt lại tốc độ Y khi bóng đã dừng nảy
        }
    }
}
