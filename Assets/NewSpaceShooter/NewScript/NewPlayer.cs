using UnityEngine;

public class NewPlayer : MonoBehaviour
{
    public GameObject destructionFX;
    public static NewPlayer instance;

    private void Awake()
    {
        if (instance == null)
            instance = this; // Gán phiên bản hiện tại của lớp này cho biến tĩnh instance.
    }

    // Phương thức xử lý sát thương cho người chơi  
    public void GetDamage(int damage)
    {
        Destruction();
    }
    // Phương thức xử lý việc hủy diệt người chơi
    void Destruction()
    {
        Instantiate(destructionFX, transform.position, Quaternion.identity); // Tạo hiệu ứng hủy diệt
        Destroy(gameObject); // Hủy đối tượng người chơi
    }
}
