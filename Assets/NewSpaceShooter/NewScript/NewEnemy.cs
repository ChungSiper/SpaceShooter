using UnityEngine;
using UnityEngine.UI;

public class NewEnemy : MonoBehaviour
{
    public GameObject destructionFX; // Hiệu ứng hủy diệt
    public static NewEnemy instance; // Biến tĩnh để lưu trữ phiên bản duy nhất của lớp này
    public Slider healthSlider;
    public float maxHealth;
    private float currentHealth;
    public float mau = 10f;
    private void Awake()
    {
        if (instance == null)
            instance = this; // Gán phiên bản hiện tại của lớp này cho biến tĩnh instance.
    }
    private void Start()
    {
        healthSlider = GetComponent<Slider>();
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BulletPlayer")
        {
            mau--;
            currentHealth = mau; // = mau;
            healthSlider.value = currentHealth;
            if (healthSlider.value == 0)
            {
               Destruction();
            }


        }
    }

    void Destruction()
    {
        
        Destroy(gameObject);
    }
}
