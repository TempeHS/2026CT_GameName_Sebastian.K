using UnityEngine;

public class SimpleEnemyChase : MonoBehaviour
{
    public Transform playerTarget;
    public float moveSpeed = 3.5f;
    public float detectionRadius = 8.0f;
    public float PlayerXPos = entity.InverseTransformPoint(target.position);
    void Update()
    {
        if (playerTarget == null) return;

        // Calculate direction and distance
        float distanceToPlayer = Vector2.Distance(transform.position, playerTarget.position);

        // Move only if the player is within range
        if (distanceToPlayer <= detectionRadius)
        {
            Vector3 direction = (playerTarget.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }

    private void Flip()
    {
        Vector3 PlayerXPos = myEntity.InverseTransformPoint(playerTarget.position);

        if (PlayerXPos.x > 0) {
            transform.localScale = new Vector3(1f, 1f, 1f);
        } else if (PlayerXPos.x < 0) {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}