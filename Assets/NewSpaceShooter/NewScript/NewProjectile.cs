using UnityEngine;

public class NewProjectile : MonoBehaviour
{
    [Tooltip("Sát thương mà một vật thể phóng ra gây ra cho một vật thể khác. Integer")]
    public int damage;

    [Tooltip("Liệu vật thể phóng ra thuộc về 'Kẻ thù' hay 'Người chơi'")]
    public bool enemyBullet;

    [Tooltip("Liệu vật thể phóng ra có bị phá hủy khi va chạm hay không")]
    public bool destroyedByCollision;

    private void OnTriggerEnter2D(Collider2D collision) // khi một vật thể phóng ra va chạm với một vật thể khác
    {
        // Nếu đạn phóng ra là của kẻ thù và va chạm với Người chơi
        if (enemyBullet && collision.tag == "NewPlayer")
        {
            // Gọi phương thức GetDamage của NewPlayer để xử lý sát thương
            // và kiểm tra xem có cần phá hủy vật thể phóng ra hay không

            NewPlayer.instance.GetDamage(damage);
            if (destroyedByCollision)
                Destruction();
        }
        //Nếu đạn phóng ra là của Người chơi và va chạm với kẻ thù
        else if (collision.CompareTag("Enemy01"))
        {
            // Gọi phương thức GetDamage của NewEnemy để xử lý sát thương
            // và kiểm tra xem có cần phá hủy vật thể phóng ra hay không
            
                Destruction();
        }
    }
    void Destruction() 
    {
        //Phá huỷ viên đạn sau khi va chạm
        Destroy(gameObject);
    }
    
}
