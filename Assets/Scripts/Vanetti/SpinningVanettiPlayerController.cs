using UnityEngine;

public class SpinningVanettiPlayerController : MonoBehaviour
{
    public float force = 100.0f;
    public float torque = 50.0f;
    private Rigidbody body;
    private GameObject ball;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.isKinematic = false;
        ball = GameObject.FindWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerToBall = ball.transform.position - transform.position;
        playerToBall.y = 0; // Ignore vertical difference
        playerToBall.Normalize(); // Direction only
        // Constant force towards the ball
        body.AddForce(playerToBall * force);

        // Constant torque to spin the player faster and faster
        body.AddTorque(Vector3.up * torque);
    }
}
