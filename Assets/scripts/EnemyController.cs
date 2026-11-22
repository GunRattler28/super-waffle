using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public int damage = 10;
    private Rigidbody2D rigidBody;
    private bool right = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (right) {
            rigidBody.linearVelocity = new Vector2(moveSpeed, rigidBody.linearVelocity.y);
        } else {
            rigidBody.linearVelocity = new Vector2(-moveSpeed, rigidBody.linearVelocity.y);
        }
    }

    void OnTriggerStay2D(Collider2D collisionObject)
    {
        PlayerController controller = collisionObject.GetComponent<PlayerController>();
        if (controller != null) {
            controller.ChangeHealth(-damage, (Vector2)transform.position);
        }
    }
}