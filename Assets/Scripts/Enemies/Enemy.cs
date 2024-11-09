using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public Sprite sprite;
    public float size = 5.0f;
  

    public float speed = 20.0f;
    public float homingStrength = 2.0f;
    
    public float maxLifetime = 30.0f;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Start()
    {
        if(target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            _rigidbody.velocity = direction * speed;
        }
        _spriteRenderer.sprite = sprite;

        
        _rigidbody.mass = 2;
    }

    private void FixedUpdate()
    {
        if (target == null) return; // Do nothing if there's no target (e.g., player destroyed)

        // Calculate direction towards the target (player)
        Vector2 directionToTarget = ((Vector2)target.position - _rigidbody.position).normalized;

        // Calculate the current direction the missile is moving in
        Vector2 currentDirection = _rigidbody.velocity.normalized;

        // Gradually turn towards the target
        Vector2 newDirection = Vector2.Lerp(currentDirection, directionToTarget, this.homingStrength * Time.fixedDeltaTime).normalized;

        // Update velocity to apply both forward speed and directional change
        _rigidbody.velocity = newDirection * speed;
    }

    private void OnCollisonEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }

}
