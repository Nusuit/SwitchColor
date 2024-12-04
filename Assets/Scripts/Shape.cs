using UnityEngine;
using UnityEngine.UI;  // Đảm bảo có sử dụng Image cho UI

public class BallColorChange : Player  // Kế thừa từ lớp Player
{
    public float moveSpeed = 1f;  // Tốc độ di chuyển của bóng
    public float swingAmount = 1f; // Độ lệch khi bóng di chuyển lên trên
    public float moveThreshold = 0.5f; // Khoảng cách để dịch chuyển bóng
    private bool isMoving = false;

    private string newColor;  // Màu hiện tại của bóng
    private Image ballImage;  // Thêm tham chiếu đến Image component

    new void Start()
    {
        base.Start();  // Gọi lại hàm Start() của lớp Player

        // Kiểm tra xem ballImage có tồn tại không trước khi sử dụng
        ballImage = GetComponent<Image>();  // Lấy Image component từ đối tượng
        if (ballImage == null)
        {
            Debug.LogError("Image component không tìm thấy trên đối tượng " + gameObject.name);
        }

        setRandomColor();  // Gán màu ban đầu cho bóng
        InvokeRepeating("ChangeColor", 2f, 2f);  // Đổi màu mỗi 2 giây
    }

    new void Update()
    {
        base.Update();  // Gọi lại hàm Update() của lớp Player

        // Hình tròn quay, đảm bảo vẫn tiếp tục quay mỗi frame
        transform.Rotate(Vector3.forward * Time.deltaTime * 50f);  // Quay xung quanh trục Z
    }

    // Hàm này sẽ được gọi mỗi khi bóng chạm vào vùng màu
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra nếu bóng chạm vào vùng màu
        Color regionColor = other.GetComponent<SpriteRenderer>().color;

        // Kiểm tra nếu màu của bóng và vùng màu trùng khớp
        if (ballImage.color == regionColor)
        {
            // Dịch chuyển bóng lên trên hình tròn và đổi màu
            if (!isMoving)
            {
                StartCoroutine(MoveBallUp());
                ChangeColor();  // Đổi màu khi chạm vào vùng màu
            }
        }
        else
        {
            Debug.Log("Màu không trùng khớp, không dịch chuyển!");
        }
    }

    // Coroutine để dịch chuyển bóng lên trên
    private System.Collections.IEnumerator MoveBallUp()
    {
        isMoving = true;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y + swingAmount, transform.position.z);
        float elapsedTime = 0f;
        while (elapsedTime < moveThreshold)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveThreshold);
            elapsedTime += Time.deltaTime * moveSpeed;
            yield return null;
        }
        transform.position = targetPosition;
        isMoving = false;
    }

    private void ChangeColor()
    {
        switch (newColor)
        {
            case "blue":
                newColor = "yellow";
                ballImage.color = colorYellow;  // Thay đổi màu cho Image
                break;
            case "yellow":
                newColor = "pink";
                ballImage.color = colorPink;  // Thay đổi màu cho Image
                break;
            case "pink":
                newColor = "purple";
                ballImage.color = colorPurple;  // Thay đổi màu cho Image
                break;
            case "purple":
                newColor = "blue";
                ballImage.color = colorBlue;  // Thay đổi màu cho Image
                break;
        }
    }
}
