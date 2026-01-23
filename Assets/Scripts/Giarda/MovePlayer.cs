using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float speed = 10.0f;
    private GameObject ball;
    private GameObject  ownGoal;

    public float rotation = 10.0f;

    //private GameObject BluePlayer;

    //private Rigidboody Redplayer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       ball = GameObject.Find("Ball");
       ownGoal = GameObject.Find("Red Goal");

      // Redplayer = GetComponent <RigidBoody> ();
    }

    // Update is called once per frame
    void Update()
    {
     
   
        if (ball.transform.position.z > 0f)
        {
          transform.LookAt(new Vector3(ownGoal.transform.position.x, transform.position.y,ownGoal.transform.position.z));
          transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            transform.LookAt(new Vector3(ball.transform.position.x, transform.position.y, ball.transform.position.z));  
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }



    }
}