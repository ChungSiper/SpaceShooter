using UnityEngine;
 public class NewDirectMoving : MonoBehaviour
    {
        [Tooltip("Tốc độ di chuyển của viên đạn")]
        public float speed;
        void Update()
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime); // Di chuyển đối tượng theo trục Y với tốc độ đã định
        }
    }
