using UnityEngine;

public class Ball : MonoBehaviour
{
    public float moveSpeed = 1f;  // Tốc độ di chuyển của bóng
    protected Renderer ballRenderer; // Trình hiển thị của bóng
    protected Color currentColor;  // Màu hiện tại của bóng

    // Các màu sắc từ Player (Sử dụng lớp con để thiết lập)
    public Color colorBlue;
    public Color colorYellow;
    public Color colorPink;
    public Color colorPurple;

    protected virtual void Start()
    {
        ballRenderer = GetComponent<Renderer>();
        setRandomColor();  // Gán màu ban đầu cho bóng
    }

    // Chức năng random màu sắc ban đầu
    protected virtual void setRandomColor()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                currentColor = colorBlue;
                ballRenderer.material.color = colorBlue;
                break;
            case 1:
                currentColor = colorYellow;
                ballRenderer.material.color = colorYellow;
                break;
            case 2:
                currentColor = colorPink;
                ballRenderer.material.color = colorPink;
                break;
            case 3:
                currentColor = colorPurple;
                ballRenderer.material.color = colorPurple;
                break;
        }
    }

    // Hàm này sẽ được gọi để thay đổi màu của bóng
    public virtual void ChangeColor()
    {
        // Chuyển màu theo chu kỳ
        if (currentColor == colorBlue)
        {
            currentColor = colorYellow;
            ballRenderer.material.color = colorYellow;
        }
        else if (currentColor == colorYellow)
        {
            currentColor = colorPink;
            ballRenderer.material.color = colorPink;
        }
        else if (currentColor == colorPink)
        {
            currentColor = colorPurple;
            ballRenderer.material.color = colorPurple;
        }
        else if (currentColor == colorPurple)
        {
            currentColor = colorBlue;
            ballRenderer.material.color = colorBlue;
        }
    }
}
