using Unity.Mathematics;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField]private Animator animator;
    [SerializeField] private Rigidbody rb;

    private float speedX;
    private float speedZ;

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
        speedX = Mathf.Abs(rb.linearVelocity.x);
        speedZ = Mathf.Abs(rb.linearVelocity.z);

        if (speedX > 0.1f || speedZ > 0.1f)
        {
            animator.SetFloat("MovementSpeed", 1);

        }
        else
        {
            animator.SetFloat("MovementSpeed", 0);
        }


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
