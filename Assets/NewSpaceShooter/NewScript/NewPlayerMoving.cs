using UnityEngine;

// Khởi tạo biến giới hạn vùng di chuyển của người chơi.
[System.Serializable]
public class NewBorder 
{
    [Tooltip("Khoảng cách từ biên màn hình đến vùng di chuyển của người chơi")]
    public float newMinXOffset = 0.5f, newMaxXOffset = 0.5f, newMinYOffset = 0.5f, newMaxYOffset = 0.5f;
    [HideInInspector] public float newMinX, newMaxX, newMinY, newMaxY;
}
public class NewPlayerMoving : MonoBehaviour
{
    //"Tooltip" Hiển thị chú thích này trong Inspector của Unity, giúp bạn hiểu ý nghĩa của các biến khi chỉnh sửa trên Editor.
    [Tooltip("Khoảng cách từ biên màn hình đến vùng di chuyển của người chơi")] 
    public NewBorder borders;
    public float speed = 5f; //Tốc độ di chuyển của người chơi.
    Camera mainCamera;              //Biến để lưu trữ camera chính của trò chơi.
    bool controlIsActive = true;    //Biến để kiểm soát việc di chuyển của người chơi.
    
    public float moveSpeed = 5f; // Tốc độ di chuyển của người chơi, có thể được điều chỉnh từ Inspector.
    public float tiltAmount = 5f; // Số lượng nghiêng của người chơi khi di chuyển, có thể được điều chỉnh từ Inspector.
    public static NewPlayerMoving instance; //Biến tĩnh để lưu trữ phiên bản duy nhất của lớp này, giúp truy cập dễ dàng từ các lớp khác.

    private void Awake() // Phương thức Awake được gọi khi đối tượng được khởi tạo.
    {
        
        if (instance == null)   //Kiểm tra xem biến tĩnh instance có được khởi tạo hay không.
            instance = this; //Gán phiên bản hiện tại của lớp này cho biến tĩnh instance.
    }
    private void Start()
    {
        mainCamera = Camera.main; //Lấy camera chính của trò chơi.
        
        RiesizeBorders(); //Gọi phương thức để điều chỉnh biên giới di chuyển của người chơi.
    }

    // Update is called once per frame
    void Update()
    {
        if (controlIsActive)
        {
            //Chỉ thị tiền xử lý biên dịch, cho phép mã này chỉ được biên dịch khi nền tảng là máy tính để bàn hoặc trình chỉnh sửa Unity.
#if UNITY_STANDALONE || UNITY_EDITOR //Nếu nền tảng hiện tại là máy tính để bàn hoặc trình chỉnh sửa

            if(Input.GetMouseButton(0)) //Nếu nút chuột trái được nhấn
            {
                Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition); //Tính toán vị trí chuột trong không gian thế giới
                mousePosition.z = transform.position.z; //Đặt giá trị z của vị trí chuột bằng với giá trị z của đối tượng người chơi
                transform.position = Vector3.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime); //Di chuyển người chơi về phía vị trí chuột
  
            }
#endif

#if UNITY_IOS || UNITY_ANDROID //Nếu nền tảng hiện tại là iOS hoặc Android

            if(Input.touchCount == 1) //Nếu có một lần chạm
            {
                Touch touch = Input.touches[0]; //Lấy thông tin về lần chạm đầu tiên
                Vector3 touchPosition = mainCamera.ScreenToWorldPoint(touch.position); //Tính toán vị trí chạm trong không gian thế giới
                touchPosition.z = transform.position.z; //Đặt giá trị z của vị trí chạm bằng với giá trị z của đối tượng người chơi
                transform.position = Vector3.MoveTowards(transform.position, touchPosition, speed * Time.deltaTime); //Di chuyển người chơi về phía vị trí chạm
            }
#endif
            transform.position = new Vector3( //Nếu người chơi vượt qua biên giới di chuyển, trả về vị trí hợp lệ
                Mathf.Clamp(transform.position.x, borders.newMinX, borders.newMaxX),
                Mathf.Clamp(transform.position.y, borders.newMinY, borders.newMaxY),
                0f
            );
        }
    }
    void RiesizeBorders() //Phương thức để điều chỉnh biên giới di chuyển của người chơi dựa trên
    {
        borders.newMinX = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + borders.newMinXOffset; //Tính toán biên trái
        borders.newMaxX = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - borders.newMaxXOffset; //Tính toán biên phải
        borders.newMinY = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + borders.newMinYOffset; //Tính toán biên dưới
        borders.newMaxY = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - borders.newMaxYOffset; //Tính toán biên trên
    }
}
