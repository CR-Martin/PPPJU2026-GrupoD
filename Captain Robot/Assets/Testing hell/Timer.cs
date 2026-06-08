using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject test;

    private float timer;
    private float maxTimer = 3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > maxTimer)
        {
            Instantiate(test);
            timer = 0;
        }
    }
}
