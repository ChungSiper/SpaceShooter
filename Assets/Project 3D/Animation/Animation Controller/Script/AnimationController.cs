using UnityEngine;


public class AnimationController : MonoBehaviour
{
    public Animator animatior;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         animatior = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool run = Input.GetKey(KeyCode.LeftShift);
        bool jump = Input.GetKeyDown(KeyCode.Space);

        animatior.SetTrigger("Jump");
        animatior.SetFloat("Speed", v);
        animatior.SetFloat("Direction", h);
        animatior.SetBool("Run", run);

    }
}
