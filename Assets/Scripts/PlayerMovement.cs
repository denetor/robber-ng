using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private float horizontalSpeed = 5f;
    [SerializeField] private float verticalSpeed = 5f;
    float horizontalMovement;
    float verticalMovement;
    int horizontalHeading = 1;
    [SerializeField] bool isSwimming = false;

    public void setSwimming(bool swimming)
    {
        isSwimming = swimming;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isSwimming = false;
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(horizontalMovement * horizontalSpeed, verticalMovement * verticalSpeed);

        // flip sprite if heading changed
        if (horizontalMovement > 0)
        {
            horizontalHeading = 1;
        }
        else if (horizontalMovement < 0)
        {
            horizontalHeading = -1;
        }
        rb.GetComponent<SpriteRenderer>().flipX = (horizontalHeading < 0);

        // set animation parameters to apply transitions, if needed
        animator.SetFloat("magnitude", rb.linearVelocity.magnitude);
        animator.SetBool("isSwimming", isSwimming);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
        verticalMovement = context.ReadValue<Vector2>().y;
    }
}
