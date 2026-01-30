using UnityEngine;

public class RandomVanettiPlayerController : MonoBehaviour
{
    Vector3 direction;
    public float speed = 15f;
    public float changeDirectionInterval = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        float maxSpeed = GetComponent<LimitPlayerMovement>().maxSpeed;
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
        InvokeRepeating(nameof(ChangeDirection), 0, changeDirectionInterval);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        if (transform.position.x < -20 || transform.position.x > 20 
            || transform.position.z < -20 || transform.position.z > 20)
        {
            direction = -transform.position;
            direction.y = 0;
            direction.Normalize();
        }
    }

    void ChangeDirection()
    {
        direction = new Vector3(
            Random.Range(-1f, 1f), 
            0, 
            Random.Range(-1f, 1f)).normalized;
    }


}
