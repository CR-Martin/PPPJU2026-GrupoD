using System.Collections;
using TMPro;
using UnityEngine;

public class LapCounter : MonoBehaviour
{
    [Header("Vueltas")]
    public int laps = 0;
    public GameObject starItem;

    [Header("UI")]
    public TMP_Text lapText;

    private Vector3 originalScale;

    private void Start()
    {
        if (starItem != null)
            starItem.SetActive(false);

        if (lapText != null)
        {
            originalScale = lapText.transform.localScale;

            Color c = lapText.color;
            c.a = 0;
            lapText.color = c;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            laps++;

            Debug.Log("Vuelta: " + laps);

            if (lapText != null)
            {
                StopAllCoroutines();
                StartCoroutine(ShowLapText());
            }

            if (laps >= 2)
            {
                starItem.SetActive(true);
                Debug.Log("Star desbloqueada!");
            }
        }
    }

    IEnumerator ShowLapText()
    {
        lapText.text = "LAP " + laps;

        Color c = lapText.color;
        c.a = 1f;
        lapText.color = c;

        lapText.transform.localScale = originalScale * 1.5f;

        float t = 0f;

        // Zoom
        while (t < 0.25f)
        {
            t += Time.deltaTime;

            lapText.transform.localScale = Vector3.Lerp(
                originalScale * 1.5f,
                originalScale,
                t / 0.25f
            );

            yield return null;
        }

        yield return new WaitForSeconds(1f);

        // Fade
        t = 0f;

        while (t < 0.5f)
        {
            t += Time.deltaTime;

            c.a = Mathf.Lerp(1f, 0f, t / 0.5f);
            lapText.color = c;

            yield return null;
        }
    }
}