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
        
    }
}
