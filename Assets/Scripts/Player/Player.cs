using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private bool _thrusting;
    private bool _reversing;
    private float _turnDirection;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _thrusting = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow));
        _reversing = (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow));

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _turnDirection = 1.0f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _turnDirection = -1.0f;
        }
        else
        {
            _turnDirection = 0.0f;
        }
    }
    private void FixedUpdate()
    {
        if (_thrusting)
        {
            // Thrust the player forward
            GetComponent<Rigidbody2D>().AddForce(transform.up * 2.0f);
        }
        if (_reversing)
        {
            GetComponent<Rigidbody2D>().AddForce(-transform.up * 2.0f);

        }
        if (_turnDirection != 0.0f)
        {
            // Rotate the player
            transform.Rotate(Vector3.forward, _turnDirection * 3.0f);
        }
    }

}
