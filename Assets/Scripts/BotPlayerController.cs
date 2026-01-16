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

            Vector3 dir = ball.transform.position - transform.position;
            dir.y = 0;
            dir.Normalize();

           if (dir != Vector3.zero) {
                transform.Translate(dir * botSpeed * Time.deltaTime, Space.World);
            }
        }


    }
}
