using UnityEngine;

public class Rotation : MonoBehaviour
{
    //GameObject sun;
    //float initialRotation;
    //float actualRotation;
    Vector3 rotationVelocity;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //localEulerAngles
    
        rotationVelocity = transform.localEulerAngles;

        //initialRotation = sun.transform.localRotation.x;
        //actualRotation = initialRotation;
    }

    // Update is called once per frame
    void Update()
    {
        rotationVelocity.y += 1;
        transform.localEulerAngles = rotationVelocity;
        //actualRotation = actualRotation + rotationVelocity;
        //sun.transform.localRotation.x = 5;
    }
}
