using UnityEngine;

public class PlayerController : MonoBehaviour

{
    public Transform ball;
    public float moveForce = 5f;
    public Transform targetGoal;
    public float behindBallDistance = 1.5f;
    public float aimTolerance = 0.6f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ball == null || targetGoal == null) return;

        // Direzione palla -> porta (solo piano)
        Vector3 ballToGoal = targetGoal.position - ball.position;
        ballToGoal.y = 0f;
        if (ballToGoal.sqrMagnitude < 0.001f) return;

        Vector3 dirToGoal = ballToGoal.normalized;

        // Punto dietro la palla
        Vector3 behindBallPos = ball.position - dirToGoal * behindBallDistance;
        behindBallPos.y = transform.position.y;

        // Direzione AI -> palla
        Vector3 aiToBall = ball.position - transform.position;
        aiToBall.y = 0f;

        float alignment = 0f;
        if (aiToBall.sqrMagnitude > 0.001f)
            alignment = Vector3.Dot(aiToBall.normalized, dirToGoal);

        // Decide dove andare
        Vector3 targetPos = (alignment > aimTolerance) ? ball.position : behindBallPos;

        // Movimento sul piano
        Vector3 moveDir = targetPos - transform.position;
        moveDir.y = 0f;

        if (moveDir.sqrMagnitude > 0.001f)
        {
            moveDir.Normalize();

            Vector3 newPos = transform.position + moveDir * moveForce * Time.deltaTime;
            newPos.y = transform.position.y;
            transform.position = newPos;

            // Ruota solo su Y
            transform.rotation = Quaternion.LookRotation(moveDir, Vector3.up);
        }
    }
}
