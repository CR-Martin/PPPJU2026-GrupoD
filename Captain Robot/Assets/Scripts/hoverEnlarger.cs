using UnityEngine;
using UnityEngine.EventSystems;

public class HoverEnlarger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float sizeDifference = 1.05f;

    private Vector3 originalScale;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rectTransform.localScale = originalScale * sizeDifference;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.localScale = originalScale;
    }
}