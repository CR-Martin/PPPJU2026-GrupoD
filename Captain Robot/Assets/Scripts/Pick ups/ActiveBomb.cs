using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private int maxTime;
    float currentTime = 0;
    
    [SerializeField] private Collider area;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > maxTime)
        {
            area.enabled = true;
        }

        if (currentTime > maxTime + 0.5)
        {
            Destroy(this);
        }

    }
}
