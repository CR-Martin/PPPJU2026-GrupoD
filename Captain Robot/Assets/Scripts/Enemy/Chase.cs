using UnityEngine;
using System.Collections;

public class Chase : MonoBehaviour
{
    public Transform player;

    public float moveSpeed = 1.5f;
    public float stoppingDistance = 1.5f;
    public float rotationSpeed = 5f;

    private bool isTimerRunning = true;
    private bool isMusicSet = false;

    private void OnEnable()
    {
        TimeStop.OnTimeStop += StopTime;

    }

    private void OnDisable()
    {
        TimeStop.OnTimeStop -= StopTime;

    }

    

    void Update()
    {
        SetMusic();
        if (player == null) return;
        if (isTimerRunning == false) return;

        Vector3 toPlayer = player.position - transform.position;
        toPlayer.y = 0f;

        float distance = toPlayer.magnitude;
        if (distance <= stoppingDistance) return;

        Vector3 moveDir = toPlayer.normalized;

        Vector3 newPos = transform.position + moveDir * moveSpeed * Time.deltaTime;
        newPos.y = transform.position.y; 
        transform.position = newPos;

        if (moveDir != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
        }
    }

    private void SetMusic()
    {
        if (isMusicSet == false)
        {
            AudioManager.Instance.PlayMusic("Boss");
            isMusicSet = true;
        }

    }
    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void PauseTimer()
    {
        isTimerRunning = false;
    }

    private void StopTime(float time)
    {
        StartCoroutine(StopForATime(time));
    }

    IEnumerator StopForATime(float time)
    {

        PauseTimer();

        yield return new WaitForSeconds(time);

        StartTimer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.TryGetComponent(out IDamageable damageable))
        {
            Debug.Log("hit interact");

            damageable.TakeDamage();

        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.gameObject.TryGetComponent(out IDamageable damageable))
        {
            Debug.Log("hit interact");

            damageable.TakeDamage();

        }
    }
}
