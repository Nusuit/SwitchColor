using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce = 5f;
    public float fallThreshold = -6f;

    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public string currentColor;

    public Color colorBlue;
    public Color colorYellow;
    public Color colorPink;
    public Color colorPurple;

    public GameObject explosionPrefab;  // Prefab của quả bóng nổ khi chạm sai màu

    private GameOverManager gameOverManager;

    protected void Start()
    {
        setRandomColor();
        gameOverManager = FindFirstObjectByType<GameOverManager>();
    }

    public float upperThreshold = 100f;

    protected void Update()
    {
        // Xử lý nhảy của player
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }

        // Kiểm tra game over nếu player rơi xuống quá thấp
        if (transform.position.y < fallThreshold)
        {
            GameOver();
        }

        // Kiểm tra game over nếu player bay quá cao
        if (transform.position.y > upperThreshold)
        {
            GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Kiểm tra va chạm với BulletPoint
        if (col.CompareTag("BulletPoint"))
        {
            // Cộng điểm khi player chạm vào BulletPoint
            ScoreManager.Instance.AddPoints(1);  // Thêm điểm vào ScoreManager
            Destroy(col.gameObject);  // Xóa BulletPoint sau khi ăn
            Debug.Log("Has eaten");

            // Đảm bảo BulletPoint đã bị hủy và tránh tiếp tục xử lý
            return; // Dừng việc xử lý tại đây sau khi xóa BulletPoint
        }

        // Kiểm tra va chạm với ColorChanger để đổi màu ngẫu nhiên
        if (col.CompareTag("colorChanger"))
        {
            setRandomColor();  // Đổi màu ngẫu nhiên khi va chạm với ColorChanger
            Debug.Log("Color changed");
            return; // Dừng xử lý ở đây nếu va chạm với colorChanger
        }

        // Nếu màu không khớp thì game over và bóng sẽ nổ
        if (col.tag != currentColor)
        {
            Explode();  // Nổ bóng nếu màu không khớp
            GameOver();  // Gọi GameOver khi màu không khớp
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

    // Hàm xử lý nổ bóng khi chạm sai màu
    void Explode()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }

    void GameOver()
    {
        Debug.Log("GameOver called");

        // Vô hiệu hóa physics và input của Player
        GetComponent<Rigidbody2D>().simulated = false;
        enabled = false;

        // Ẩn tất cả BulletPoints
        GameObject[] bulletPoints = GameObject.FindGameObjectsWithTag("BulletPoint");
        foreach (GameObject bulletPoint in bulletPoints)
        {
            bulletPoint.SetActive(false);
        }

        // Hiện GameOverPanel
        if (gameOverManager != null)
        {
            gameOverManager.ShowGameOverPanel();
        }
        else
        {
            gameOverManager = FindFirstObjectByType<GameOverManager>();
            if (gameOverManager != null)
            {
                gameOverManager.ShowGameOverPanel();
            }
            else
            {
                Debug.LogError("GameOverManager Instance is null!");
            }
        }
    }
}
