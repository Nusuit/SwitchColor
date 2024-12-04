using UnityEngine;

public class BallColorChange : Player  // Kế thừa từ lớp Player
{
    public float moveSpeed = 1f;  // Tốc độ di chuyển của bóng
    public float swingAmount = 1f; // Độ lệch khi bóng di chuyển lên trên
    public float moveThreshold = 0.5f; // Khoảng cách để dịch chuyển bóng
    private bool isMoving = false;

    private string currentColor;  // Màu hiện tại của bóng

    new void Start()
    {
        base.Start();  // Gọi lại hàm Start() của lớp Player

        // Kiểm tra xem rb có tồn tại không trước khi sử dụng
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();  // Lấy Rigidbody2D của đối tượng nếu chưa gán
            if (rb == null)
            {
                Debug.LogError("Rigidbody2D không tìm thấy trên đối tượng " + gameObject.name);
            }
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

    // Hàm gọi khi đối tượng được tạo ra (hoặc nạp vào Scene)
    void Awake()
    {
        // Gán giá trị cho rb nếu chưa được gán
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();  // Lấy Rigidbody2D của đối tượng
        }
    }

    // Hàm này sẽ được gọi mỗi khi bóng chạm vào vùng màu
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra nếu bóng chạm vào vùng màu
        Color regionColor = other.GetComponent<SpriteRenderer>().color;

        // Kiểm tra nếu màu của bóng và vùng màu trùng khớp
        if (GetComponent<Renderer>().material.color == regionColor)
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
        switch (currentColor)
        {
            case "blue":
                currentColor = "yellow";
                GetComponent<Renderer>().material.color = colorYellow;
                break;
            case "yellow":
                currentColor = "pink";
                GetComponent<Renderer>().material.color = colorPink;
                break;
            case "pink":
                currentColor = "purple";
                GetComponent<Renderer>().material.color = colorPurple;
                break;
            case "purple":
                currentColor = "blue";
                GetComponent<Renderer>().material.color = colorBlue;
                break;
        }
    }
}
