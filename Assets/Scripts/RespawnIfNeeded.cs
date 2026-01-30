using UnityEngine;

public class RespawnIfNeeded : MonoBehaviour
{
    public Vector3 respawnPosition = new Vector3(0, 3, 0);
    private Rigidbody body;
    private Vector3 areaCenter;
    private float areaRadius = 1.0f;
    private float timeStuckInSameArea = 0.0f;
    private float maxTimeStuckInSameArea = 3.0f;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        areaCenter = transform.position;
    }

    void FixedUpdate()
    {
        // Respawn when falling much below the ground
        if (transform.position.y < -10)
        {
            Respawn();
        }
    }

    public void Respawn()
    {        
        transform.position = respawnPosition;
        body.linearVelocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Vector3.Distance(areaCenter, transform.position) < areaRadius)
            {
                timeStuckInSameArea += Time.deltaTime;
                if (timeStuckInSameArea >= maxTimeStuckInSameArea)
                {
                    Debug.Log(gameObject.name + " stuck for " + timeStuckInSameArea + "s near " + areaCenter + ", respawning");
                    Respawn();
                    timeStuckInSameArea = 0.0f;
                }
            }
            else
            {
                areaCenter = transform.position;
                timeStuckInSameArea = Time.deltaTime;
            }
        }
    }
}
