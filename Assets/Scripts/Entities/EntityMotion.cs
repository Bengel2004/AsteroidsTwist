using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMotion : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Rigidbody2D rb;
    [SerializeField]
    private bool useRandomSpeed;

    // adds motion to the entity on Instantiation
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        ApplyForwardForce();
    }

    private void OnDisable()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        Debug.Log(rb.velocity);
    }

    public void ApplyForwardForce()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        if (useRandomSpeed)
        {
            float _randomSpeed = Random.Range(1150, 2000);
            _randomSpeed = Mathf.Round((_randomSpeed / 100)) * 100;
            speed = _randomSpeed;
        }
        rb.AddRelativeForce(new Vector2(0, speed));
    }
}
