using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private float horizontalSpeed = 5f;
    [SerializeField] private float verticalSpeed = 5f;
    // Speed at which air drains when swimming, in units per second
    private float airDrainSpeedSwimming = 15f;
    // Speed at which air gains when not swimming, in units per second
    private float airGainSpeed = 10f;
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
        // movement speed is reduced when swimming
        float asjustedHorizontalSpeed = isSwimming ? horizontalSpeed / 2 : horizontalSpeed;
        float asjustedVerticalSpeed = isSwimming ? verticalSpeed / 2 : verticalSpeed;
        rb.linearVelocity = new Vector2(horizontalMovement * asjustedHorizontalSpeed, verticalMovement * asjustedVerticalSpeed);

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


        
        // Drain air when swimming
        BreathSystem breathSystem = GetComponent<BreathSystem>();
        if (breathSystem != null)
        {
            if (isSwimming)
            {
                rb.GetComponent<SpriteRenderer>().color = new Color(0.7f, 0.7f, 1f, 0.7f); // Change color to indicate swimming
                breathSystem.Change(-airDrainSpeedSwimming * Time.deltaTime);
            }
            else
            {
                rb.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f); // Change color to indicate swimming
                breathSystem.Change(airGainSpeed * Time.deltaTime);
            }
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
        verticalMovement = context.ReadValue<Vector2>().y;
    }
}
