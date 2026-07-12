using UnityEngine;
using System.Collections;

public class PlayerGravity : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private int maxTime;

    [SerializeField] private GameObject visual;

    private void OnEnable()
    {
        Wings.OnFlying += TurnOffGravity;
    }

    private void OnDisable()
    {
        Wings.OnFlying -= TurnOffGravity;

    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
  
    private void TurnOffGravity()
   {
        StartCoroutine("Float");

   }

    IEnumerator Float()
    {
        rb.useGravity = false;
        rb.constraints |= RigidbodyConstraints.FreezePositionY;
        visual.SetActive(true);
        yield return new WaitForSeconds(maxTime);
        visual.SetActive(false);
        rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
        rb.useGravity = true;

        yield return null;
    }
}
