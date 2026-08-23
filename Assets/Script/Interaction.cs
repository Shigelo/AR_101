using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private float multiplier = 2f;

    private Vector3 originalSize;
    private bool bigSize = false;
    // Start is calle d once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalSize = transform.localScale;
    }

    void OnMouseDown()
    {
        if(bigSize)
        {
            transform.localScale = originalSize;
        }
        else
        {
            transform.localScale = originalSize * multiplier;
        }

        bigSize = !bigSize;
    }
}
