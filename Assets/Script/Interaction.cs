using UnityEngine;
using UnityEngine.EventSystems;
public class Interaction : MonoBehaviour
{
    [SerializeField] private float multiplier = 2f;

    private Vector3 originalSize;
    private bool bigSize = false;
    // Start is calle d once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        originalSize = transform.localScale;
    }

    void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnClick");
        bigSize = !bigSize;
        transform.localScale = bigSize ? originalSize * multiplier : originalSize;

        
    }
}
