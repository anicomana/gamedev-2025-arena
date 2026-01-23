using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AiPlayerCaporale : MonoBehaviour
{

    public float speed = 15f;
    public float rotationSpeed = 100.0f;
    private Rigidbody player;
    private GameObject ball;
    private GameObject enemy;
    public bool attack;
    public float attackDuration = 5f;
    public float ticleDuration =5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Rigidbody>();
        player.isKinematic = true;
        ball = GameObject.FindWithTag("Ball");
        enemy = GameObject.Find("Red Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (attack)
        {
            Vector3 direction = ball.transform.position - transform.position;
            direction.y = 0;
            direction = direction.normalized;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
        else
        {
            Vector3 enemyPosition = (enemy.transform.position - transform.position).normalized;
            enemyPosition.y = 0;
            transform.Translate(enemyPosition * speed * Time.deltaTime, Space.World);
            return;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!attack && collision.gameObject.CompareTag("Ball"))
        {
            StartCoroutine(AttackCooldown());
        }

    }
    IEnumerator AttackCooldown()
    {
        speed /= 2;
        yield return new WaitForSeconds(attackDuration);
        attack = true;
        speed *= 2;
        yield return new WaitForSeconds(ticleDuration);
        attack = false;
    }
}
