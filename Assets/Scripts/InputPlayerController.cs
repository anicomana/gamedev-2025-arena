using UnityEngine;

public class InputPlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    void Start()
    {
        MoveCamera moveCamera = Camera.main.GetComponent<MoveCamera>();
        if (moveCamera.enabled)
        {
            Camera.main.GetComponent<MoveCamera>().enabled = false;
            Debug.LogWarning("InputPlayerController activated: Camera movement disabled");
        }
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
        transform.Translate(speed * verticalInput * Time.deltaTime * Vector3.forward);
    }
}
