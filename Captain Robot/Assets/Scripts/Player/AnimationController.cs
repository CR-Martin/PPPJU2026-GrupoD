using Unity.Mathematics;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField]private Animator animator;
    [SerializeField] private Rigidbody rb;

    private void OnEnable()
    {
        PlayerController.OnPickUp += ItemPickUpI;
        PlayerController.OnDropAction += DropUpItem;
        PlayerController.OnDropAction += DropUpItem;

        PlayerHealth.OnStarDamage += StarDamage;
        PlayerHealth.OnEndDamage += StopDamage;

    }

    private void OnDisable()
    {
        PlayerController.OnPickUp -= ItemPickUpI;
        PlayerController.OnDropAction -= DropUpItem;
        PlayerController.OnDropAction -= DropUpItem;

        PlayerHealth.OnStarDamage -= StarDamage;
        PlayerHealth.OnEndDamage -= StopDamage;
    }
    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>();
        }
        if (rb == null)
        {
            rb = GetComponentInChildren<Rigidbody>();
        }

    }

    void Update()
    {
        SetRunAnimation();
    }

    private void SetRunAnimation()
    {
        animator.SetFloat("MovementSpeed", Mathf.Abs(rb.linearVelocity.x));
        animator.SetFloat("MovementSpeed", Mathf.Abs(rb.linearVelocity.z));

    }

    private void ItemPickUpI()
    {
      

        animator.SetBool("Holding", true);
        
    }

    private void DropUpItem()
    {
       
        animator.SetBool("Holding", false);

    }

    private void StarDamage()
    {
        animator.SetBool("Damage", true);

    }

    private void StopDamage()
    {
        animator.SetBool("Damage", false);

    }

}
