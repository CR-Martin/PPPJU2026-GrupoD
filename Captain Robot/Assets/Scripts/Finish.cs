using UnityEngine;

public class LapCounter : MonoBehaviour
{
    public int laps = 0;
    public GameObject starItem;

    private void Start()
    {
        if (starItem != null)
            starItem.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            laps++;

            Debug.Log("Vuelta: " + laps);

            if (laps >= 2)
            {
                starItem.SetActive(true);
                Debug.Log("Star desbloqueada!");
            }
        }
    }
}