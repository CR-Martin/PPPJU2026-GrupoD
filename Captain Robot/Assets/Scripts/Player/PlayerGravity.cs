using UnityEngine;
using System.Collections;

public class PlayerGravity : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private int maxTime;

    private void OnEnable()
    {
        Inmune.OnInmunity += TurnOffGravity;
    }

    private void OnDisable()
    {
        Inmune.OnInmunity -= TurnOffGravity;

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
        yield return new WaitForSeconds(maxTime);
        Debug.Log("Unfreze");
        rb.constraints &= ~RigidbodyConstraints.FreezePositionY;
        rb.useGravity = true;

        yield return null;
    }
}
