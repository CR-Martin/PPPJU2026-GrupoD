using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField]private Animator animator;
    [SerializeField] private Rigidbody rb;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        SetRunAnimation();
    }

    private void SetRunAnimation()
    {
        animator.SetFloat("MovementSpeed", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("MovementSpeed", Mathf.Abs(rb.linearVelocity.z));

    }
}
