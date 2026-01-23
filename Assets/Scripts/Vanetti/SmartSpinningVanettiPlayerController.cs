using UnityEngine;

public class SmartSpinningVanettiPlayerController : MonoBehaviour
{
    public float force = 100.0f;
    public float torque = 50.0f;
    private Rigidbody body;
    private GameObject ball;
    private Vector3 ownGoalPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.isKinematic = false;
        ball = GameObject.FindWithTag("Ball");
        if (GetComponent<TeamMember>().team == 0)
        {
            ownGoalPosition = GameObject.Find("Red Goal").transform.position;
        }
        else
        {
            ownGoalPosition = GameObject.Find("Blue Goal").transform.position;
        }
    }

    bool MustRunToDefendGoal()
    {

        if (Vector3.Distance(ball.transform.position, ownGoalPosition) <
                Vector3.Distance(transform.position, ownGoalPosition))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target;
        if (MustRunToDefendGoal())
        {
            target = ownGoalPosition;
        }
        else
        {
            target = ball.transform.position;            
        }
        Vector3 playerToTarget = target - transform.position;
        playerToTarget.y = 0; // Ignore vertical difference
        playerToTarget.Normalize(); // Direction only                                      
        body.AddForce(playerToTarget * force); // Constant force towards the target
        // Constant torque to spin the player faster and faster
        body.AddTorque(Vector3.up * torque);
    }
}
