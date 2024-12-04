using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpForce = 8f;
    public float fallThreshold = -10f;

    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public string currentColor;

    public Color colorBlue;
    public Color colorYellow;
    public Color colorPink;
    public Color colorPurple;

    protected void Start()
    {
        setRandomColor();
    }

    public float upperThreshold = 100f;
    public AudioClip jumpSound;

    protected void Update()
    {
        // Xử lý nhảy của player
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = Vector2.up * jumpForce;

            // Phát âm thanh khi nhảy
            if (AudioManager.Instance != null && jumpSound != null)
            {
                AudioManager.Instance.soundEffectSource.PlayOneShot(jumpSound);
            }
        }

        // Kiểm tra game over nếu player rơi xuống quá thấp
        if (transform.position.y < fallThreshold)
        {
            Debug.Log("Too Deepppp!!!");
            GameOver();
        }

        // Kiểm tra game over nếu player bay quá cao
        if (transform.position.y > upperThreshold)
        {
            Debug.Log("Reached too high! Resetting scene...");
            GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Kiểm tra va chạm với color changer để thay đổi màu
        if (col.CompareTag("colorChanger"))
        {
            setRandomColor();
            Destroy(col.gameObject);
            return;
        }

        // Kiểm tra nếu màu của player không khớp với màu của vật chạm phải
        if (col.CompareTag("BulletPoint"))
        {
            // Cộng điểm khi player chạm vào BulletPoint
            ScoreManager.Instance.AddPoints(1); // Thêm điểm vào ScoreManager
        }

        // Nếu màu không khớp thì game over
        if (col.tag != currentColor)
        {
            Debug.Log("GAME OVER!!!");
            GameOver();
        }
    }

    // Chức năng random màu sắc
    protected void setRandomColor()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                currentColor = "blue";
                sr.color = colorBlue;
                break;
            case 1:
                currentColor = "yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "pink";
                sr.color = colorPink;
                break;
            case 3:
                currentColor = "purple";
                sr.color = colorPurple;
                break;
        }
    }

    // Hàm xử lý game over, trở lại màn chính
    void GameOver()
    {
        // Hiển thị Game Over và điểm số
        GameOverManager.Instance.ShowGameOverPanel();
    }
}
