using UnityEngine;

public class NearBallVanettiPlayerController : MonoBehaviour
{
    public float force = 1000.0f;
    public float deviationAngle = 15f; // degrees
    private GameObject ball;
    private Vector3 goalPosition;
    private Rigidbody body;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.isKinematic = false;
        ball = GameObject.FindWithTag("Ball");
        if (GetComponent<TeamMember>().team == 0)
        {
            goalPosition = GameObject.Find("Blue Goal").transform.position;            
        }
        else
        {
            goalPosition = GameObject.Find("Red Goal").transform.position;
        }
    }
    
    void FixedUpdate()
    {       
        Vector3 ballToGoal = goalPosition - ball.transform.position;
        ballToGoal.y = 0; // Ignore vertical difference
        ballToGoal.Normalize();
        float deviationInRadians = deviationAngle * Mathf.Deg2Rad;
        if (ballToGoal.x > 0)
        {
            ballToGoal = Vector3.RotateTowards(ballToGoal, Vector3.right, deviationInRadians, 0);
        }
        else
        {
            ballToGoal = Vector3.RotateTowards(ballToGoal, Vector3.left, deviationInRadians, 0);
        }
        
        float ballDistance = Vector3.Distance(transform.position, ball.transform.position);
        Vector3 target = ball.transform.position - (ballDistance * 0.5f * ballToGoal);

        Vector3 playerToTarget = target - transform.position;
        playerToTarget.y = 0; // Ignore vertical difference
        playerToTarget.Normalize();

        body.AddForce(playerToTarget * force);
    }
}
