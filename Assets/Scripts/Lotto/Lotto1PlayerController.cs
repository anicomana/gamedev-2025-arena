using UnityEditor.Rendering;
using UnityEngine;

public class Lotto1PlayerController : MonoBehaviour

{
  private Rigidbody playerRb;
  public float speed = 10.0f;
  private GameObject ball;
  private Vector3 ownGoalPosition;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    playerRb = GetComponent<Rigidbody>();
    ball = GameObject.Find("Ball");
    playerRb.isKinematic = false;
    if (GetComponent<TeamMember>().team == 0)
    {
      ownGoalPosition = GameObject.Find("Blue Goal").transform.position;
    }
    else
    {
      ownGoalPosition = GameObject.Find("Red Goal").transform.position;
    }
  }

    // Update is called once per frame
    void FixedUpdate()

    {
      Vector3 v;

      v = ball.transform.position - transform.position;
      v.y = 0;
      v = v.normalized;

      playerRb.AddForce(v * speed);
    }
}