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
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = Vector2.up * jumpForce;

            // Phát âm thanh khi nhảy
            if (AudioManager.Instance != null && jumpSound != null)
            {
                AudioManager.Instance.soundEffectSource.PlayOneShot(jumpSound);
            }
        }

        if (transform.position.y < fallThreshold)
        {
            Debug.Log("Too Deepppp!!!");
            GameOver();
        }

        if (transform.position.y > upperThreshold)
        {
            Debug.Log("Reached too high! Resetting scene...");
            GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "colorChanger")
        {
            setRandomColor();
            Destroy(col.gameObject);
            return;
        }
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
        // Chuyển về Main Menu sau khi thua
        SceneManager.LoadScene("MainMenu");
    }
}
