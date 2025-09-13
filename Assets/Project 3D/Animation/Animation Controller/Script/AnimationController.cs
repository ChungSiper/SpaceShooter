using UnityEngine;


public class AnimationController : MonoBehaviour
{
    private Animator _animatior;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         _animatior = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        _animatior.SetFloat("Speed", v);
        _animatior.SetFloat("Horizontal", h);

        //Nhảy lên
        if (Input.GetButtonDown("Jump"))
        {
            _animatior.SetTrigger("Jump");
        }
        //Chạy nước rút
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _animatior.SetBool("Runing", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _animatior.SetBool("Runing", false);
        }


    }
}
