using UnityEngine;

public class NewEnemy : MonoBehaviour
{
    public GameObject destructionFX; // Hiệu ứng hủy diệt
    public static NewEnemy instance; // Biến tĩnh để lưu trữ phiên bản duy nhất của lớp này
    private void Awake()
    {
        if (instance == null)
            instance = this; // Gán phiên bản hiện tại của lớp này cho biến tĩnh instance.
    }
    public void GetDamage(int damage)
    {
        Destruction();
    }
    void Destruction()
    {
        Instantiate(destructionFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
