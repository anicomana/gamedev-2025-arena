using UnityEngine;

public class LimitPlayerMovement : MonoBehaviour
{
    public float maxSpeed = 20f;    
    public float maxRotationSpeed = 180f; // degrees per second
    private Vector3 previousPosition;
    private Quaternion previousRotation;
    private Rigidbody body;

    void Start()
    {        
        previousPosition = transform.position;
        previousRotation = transform.rotation;
    }

    private void FixedUpdate()
    {
        
    }

    void LateUpdate()
    {        
        // Linear speed limit
        Vector3 currentPosition = transform.position;
        Vector3 deltaPosition = currentPosition - previousPosition;
        float speed = deltaPosition.magnitude / Time.deltaTime;
        // If speed exceeds maxSpeed, limit the movement
        if (speed > maxSpeed)
        {
            Vector3 limitedDeltaPosition = maxSpeed * Time.deltaTime * deltaPosition.normalized;
            transform.position = previousPosition + limitedDeltaPosition;
        }
        // Update previous position for the next frame
        previousPosition = transform.position;

        // Angular speed limit
        Quaternion currentRotation = transform.rotation;
        float angle = Quaternion.Angle(previousRotation, currentRotation);
        float rotationSpeed = angle / Time.deltaTime;
        // If rotation speed exceeds maxRotationSpeed, limit the rotation
        if (rotationSpeed > maxRotationSpeed)
        {
            float limitedAngle = maxRotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(previousRotation, currentRotation, limitedAngle);
        }
        // Update previous rotation for the next frame
        previousRotation = transform.rotation;
    }
}
