using UnityEngine;

public class PlayerRed : MonoBehaviour
{
    public Transform ball;
    public Transform goal;
    public float speed = 10f;
    public float behindballDistance = 1.5f;
    public float stopDistance = 0.25f;
    public Transform PlayerBlue;
    public float avoidDistance = 1f;
    public float avoidForce = 5f;
    

    public float kickForce = 10f;

    Rigidbody rb;
    bool kicked = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if (kicked) return;
        Vector3 ballToGoal = (goal.position - ball.position);
        ballToGoal.y = 0f;
        ballToGoal = ballToGoal.normalized;
        Vector3 avoidDir = Vector3.zero;
        if (Vector3.Distance(transform.position, PlayerBlue.position) < avoidDistance)
        {
            avoidDir = transform.position - PlayerBlue.position;
            avoidDir.y = 0f;
            avoidDir = avoidDir.normalized * avoidForce;
        }
        

       

        Vector3 kickPoint = ball.position - ballToGoal * behindballDistance;
        Vector3 toKickPoint = kickPoint - rb.position;
        toKickPoint.y = 0f;
        if (toKickPoint.magnitude > stopDistance)
        {
            Vector3 step = toKickPoint.normalized * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + step);
            rb.MoveRotation(Quaternion.LookRotation(toKickPoint.normalized));

        }
        Vector3 finalDir = toKickPoint.normalized + avoidDir;
        finalDir = finalDir.normalized;
        rb.MovePosition(rb.position + finalDir * speed * Time.fixedDeltaTime);   
    }

    void OnCollisionEnter(Collision collision)
    {
        // if (kicked) return;
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 dir = (goal.position - ball.position);
            dir.y = 0f;
            dir = dir.normalized;
            ballRb.AddForce(dir * kickForce, ForceMode.Impulse);
            kicked = true;
        }
    }

}

