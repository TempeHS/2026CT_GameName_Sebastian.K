using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform playerTarget;
    public float moveSpeed = 3.5f;
    public float detectionRadius = 8.0f;
    public Vector2 PlayerXPos;
    public Transform flipTarget;
    
    void Start()
    {
        PlayerXPos = flipTarget.InverseTransformPoint(playerTarget.position);
    }
    void Update()
    {
        if (playerTarget == null) return;

        Flip();

        float distanceToPlayer = Vector2.Distance(transform.position, playerTarget.position);
       
        if (distanceToPlayer <= detectionRadius)
        {
            Vector3 direction = (playerTarget.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }

    private void Flip()
    {
        Vector2 PlayerXPos = flipTarget.InverseTransformPoint(playerTarget.position);

        if (PlayerXPos.x > 0) 
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        if (PlayerXPos.x < 0) 
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
    }
}