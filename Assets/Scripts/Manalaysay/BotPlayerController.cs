using UnityEngine;

public class BotPlayerController : MonoBehaviour


{
    public float botSpeed = 10f;
    public float botRotationSpeed = 180f;
    public float behindDistance = 1.5f;
    public float distanceThreshold = 0.5f;

    private GameObject goal;
    private GameObject ball;
    private Vector3 moveTarget;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ball = GameObject.FindWithTag("Ball");

        //Find the best way to find right goal without comparing names
        if (gameObject.name == "Red Player") {
            goal = GameObject.Find("Red Goal");
        } else if (gameObject.name == "Blue Player") {
            goal = GameObject.Find("Blue Goal");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ball != null) {
           
            //find ball direction to goal
            Vector3 goalDir = goal.transform.position - ball.transform.position;
            goalDir.y = 0;
            goalDir.Normalize();

            //set bot targetpos behind the ball to push towards goal
            Vector3 targetOnBall = ball.transform.position - goalDir * behindDistance;


            Vector3 vectorToBall = ball.transform.position - transform.position;
            float distanceToBall = vectorToBall.magnitude;

            if (distanceToBall < distanceThreshold) {
                moveTarget = ball.transform.position;
            }
            else { moveTarget = targetOnBall; }

            MoveTowardsTarget(moveTarget);
        }
    }

    void MoveTowardsTarget(Vector3 whereToMove)
    {
        Vector3 dir = whereToMove - transform.position;
            dir.y = 0;
            dir.Normalize();

           if (dir != Vector3.zero) {
                Quaternion targetRotation = Quaternion.LookRotation(dir);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, botRotationSpeed * Time.deltaTime);
                transform.Translate(Vector3.forward * botSpeed * Time.deltaTime); //Space.World serve per dare indicazioni su quale trasformate prendere riferimento.
            }
    }
}
