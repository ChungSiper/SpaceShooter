using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject BallPrefab;
    public Transform firePoint;
    public float FireRate = 20f;
    public float nextFire = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFire)
        {
            Shoot();
            nextFire = Time.time + 1f / FireRate;
        }
        

    }
    void Shoot()
    {
        GameObject Ball = Instantiate(BallPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = Ball.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * FireRate, ForceMode.Impulse);
    }
}
