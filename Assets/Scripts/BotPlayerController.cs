using UnityEngine;

public class BotPlayerController : MonoBehaviour


{
    public float botSpeed = 10f;
    private GameObject ball;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       ball = GameObject.FindWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        if (ball != null) {

            Vector3 dir = transform.position - ball.transform.position;
            dir.y = 0;
            dir.Normalize();

            if (dir != Vector3.zero) {
                //transform.LookAt(ball.transform.position);
                //Quaternion botRotation = Quaternion.LookRotation(ball.transform.position);
                //transform.rotation = botRotation;
                transform.Translate(dir * botSpeed * Time.deltaTime);
            }
        }


    }
}
