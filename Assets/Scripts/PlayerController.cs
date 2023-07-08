using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 2f;
    public float turnDrag = 0.6f;

    public bool featherControl = true;

    public GameObject firebreath;

    Vector2 moveInput = Vector2.zero;
    public bool isFiring = false;
    Rigidbody2D rb;
    PlayerInput input;
    InputAction fireAction;

    float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        input = rb.GetComponent<PlayerInput>();
        fireAction = input.actions.FindAction("fire", true);
        firebreath.SetActive(false);
        fireAction.started += ctx =>
        {
            firebreath.SetActive(true);
        };
        fireAction.canceled += ctx =>
        {
            firebreath.SetActive(false);
        };
    }

    // FixedUpdate is called once per frame at consistent cadence, for physics code
    void FixedUpdate()
    {
        if (featherControl)
        {
            if (moveInput.magnitude > Vector2.kEpsilon)
            {
                float targetDir = Mathf.Atan2(moveInput.x, -moveInput.y) * 180 / Mathf.PI;
                float turn = Mathf.DeltaAngle(targetDir, rb.rotation);
                float speed = Mathf.Abs(turn) > turnSpeed ? moveSpeed * turnDrag : moveSpeed;
                rb.rotation += Mathf.Sign(turn) * Mathf.Min(Mathf.Abs(turn), turnSpeed);
                rb.velocity = -speed * new Vector2(Mathf.Sin(rb.rotation * Mathf.PI / 180), -Mathf.Cos(rb.rotation * Mathf.PI / 180));
            }
            else
            {
                rb.velocity *= 0.9f;
            }
        }
        else
        {
            float turn = -moveInput.x * turnSpeed;
            if (moveInput.y > 0)
            {
                speed = 0.2f * speed + 0.8f * moveSpeed;
            }
            else if (moveInput.y < 0)
            {
                speed *= 0.9f;
            }
            rb.rotation += turn;
            rb.velocity = speed * new Vector2(-Mathf.Sin(rb.rotation * Mathf.PI / 180), Mathf.Cos(rb.rotation * Mathf.PI / 180)); ;
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
