using UnityEngine;

public class XuLyVaCham : MonoBehaviour
{
    
    public float mau = 3;
    public float speed = 5f; // Speed of the object
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the object forward at the specified speed
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy_001"))
        {
            mau++;
            Debug.Log("Va cham voi Enemy_001, mau hien tai: " + mau);
            Destroy(collision.gameObject);
            
        }
    }
}
