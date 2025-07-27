using UnityEngine;


[System.Serializable]
// guns objects in 'Player's' hierarchy
public class newGuns
{
    public GameObject rightGun, leftGun, centralGun;
    [HideInInspector] public ParticleSystem leftGunVFX, rightGunVFX, centralGunVFX;
}
public class NewPlayerShooting : MonoBehaviour
{
    //Khởi tạo biến tốc độ bắn
    public float fireRate;
    public GameObject projectileObject; // prefab đạn
    [HideInInspector] public float nextFire; // thời gian cho phát bắn mới

    [Tooltip("current weapon power")]
    [Range(1, 4)] // thay đổi nếu bạn muốn
    public int weaponPower = 1; // sức mạnh vũ khí hiện tại

    public newGuns guns; // đối tượng súng
    bool shootingIsActive = true; // trạng thái bắn
    [HideInInspector] public int maxweaponPower = 4; // sức mạnh vũ khí tối đa
    public static NewPlayerShooting instance; // instance của lớp
    private void Awake()
    {
        if (instance == null)
            instance = this; // đảm bảo chỉ có một instance
    }
    private void Start()
    {
        // Nhận các thành phần hiệu ứng hình ảnh bắn
        guns.leftGunVFX = guns.leftGun.GetComponent<ParticleSystem>();
        guns.rightGunVFX = guns.rightGun.GetComponent<ParticleSystem>();
        guns.centralGunVFX = guns.centralGun.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (shootingIsActive)
        {
            if (Time.time > nextFire)
            {
                MakeAShot(); // thực hiện phát bắn
                nextFire = Time.time + 1 / fireRate; // cập nhật thời gian cho phát bắn tiếp theo
            }
        }
    }
    // Phương thức để thực hiện phát bắn
    void MakeAShot()
    {
        switch (weaponPower) 
        {
            case 1:
                CreateLazerShot(projectileObject, guns.centralGun.transform.position, Vector3.zero);
                guns.centralGunVFX.Play(); // phát hiệu ứng hình ảnh cho súng trung tâm
                break;
            case 2:
                CreateLazerShot(projectileObject, guns.rightGun.transform.position, Vector3.zero);
                guns.rightGunVFX.Play(); // phát hiệu ứng hình ảnh cho súng bên phải
                CreateLazerShot(projectileObject, guns.leftGun.transform.position, Vector3.zero);
                guns.leftGunVFX.Play(); // phát hiệu ứng hình ảnh cho súng bên trái
                break;
            case 3:
                CreateLazerShot(projectileObject, guns.centralGun.transform.position, Vector3.zero);
                guns.centralGunVFX.Play(); // phát hiệu ứng hình ảnh cho súng trung tâm
                CreateLazerShot(projectileObject, guns.rightGun.transform.position, Vector3.zero);
                guns.rightGunVFX.Play(); // phát hiệu ứng hình ảnh cho súng bên phải
                CreateLazerShot(projectileObject, guns.leftGun.transform.position, Vector3.zero);
                guns.leftGunVFX.Play(); // phát hiệu ứng hình ảnh cho súng bên trái
                break;

            case 4:
                CreateLazerShot(projectileObject, guns.centralGun.transform.position, Vector3.zero);
                CreateLazerShot(projectileObject, guns.rightGun.transform.position, new Vector3(0, 0, -5));
                guns.leftGunVFX.Play();
                CreateLazerShot(projectileObject, guns.leftGun.transform.position, new Vector3(0, 0, 5));
                guns.rightGunVFX.Play();
                CreateLazerShot(projectileObject, guns.leftGun.transform.position, new Vector3(0, 0, 15));
                CreateLazerShot(projectileObject, guns.rightGun.transform.position, new Vector3(0, 0, -15));
                break;
        }
    }
    // Phương thức để tăng sức mạnh vũ khí
    void CreateLazerShot(GameObject projectile, Vector3 position, Vector3 rotation)
    {
        Instantiate(projectile, position, Quaternion.Euler(rotation)); // tạo đạn tại vị trí và xoay đã cho
    }
}
