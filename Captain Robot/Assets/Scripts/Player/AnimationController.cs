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
        PlayerController.OnPickUp += ItemPickUpI;
        PlayerController.OnDropAction += DropUpItem;
        PlayerController.OnDropAction += DropUpItem;
    }
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

    private void ItemPickUpI()
    {
        //float currentLayerWeight = animator.GetLayerWeight(1);
        //float targetLayerWeight = 0.5f;
        //float newLayerWeight;

        animator.SetBool("Holding", true);
        //newLayerWeight = Mathf.MoveTowards(currentLayerWeight, targetLayerWeight, Time.deltaTime * 5);

        //animator.SetLayerWeight(1,0.5f);
    }

    private void DropUpItem()
    {
        //float currentLayerWeight = animator.GetLayerWeight(1);
        //float targetLayerWeight = 0;

        //float newLayerWeight = Mathf.MoveTowards(currentLayerWeight, targetLayerWeight, Time.deltaTime * 5);
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
