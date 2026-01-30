using System.Collections;
using UnityEngine;

public class AiPlayerGuarnieri : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    private GameObject ball;
    private Rigidbody player;
    public bool defend;
    public GameObject soccerGoal;
    public float attackDuration = 0.5f;
    public float defendDuration = 3.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ball = GameObject.FindWithTag("Ball");
        player = GetComponent<Rigidbody>();        
        defend = false;
    }

    // Update is called once per frame
    void Update() 

    {
        if (defend)
        {
            Vector3 defendPosition = (soccerGoal.transform.position - transform.position).normalized;
            defendPosition.y = 0;
            transform.Translate(defendPosition * speed * Time.deltaTime, Space.World);
            return;
        }
        else
        {
            Vector3 direction = ball.transform.position - transform.position;
            direction.y = 0;
            direction = direction.normalized;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!defend && collision.gameObject.CompareTag("Ball"))
        {         
            StartCoroutine(DefendCooldown());
        }

    }


    IEnumerator DefendCooldown()
    {
        speed /= 2;
        yield return new WaitForSeconds(attackDuration);
        defend = true;
        speed *= 2;
        yield return new WaitForSeconds(defendDuration);
        defend = false;
    }
}


