using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    float x;
    public float speed;
    public Rigidbody2D rb;
    public Transform target;
    
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
    }

    void LateUpdate()
    {
        if (target != null)
        {
            Vector2 desiredPosition = target.position;
            transform.position = Vector2.Lerp(transform.position, desiredPosition, Time.deltaTime);
        }
    }

}

