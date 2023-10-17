using UnityEngine;

public enum States
{
    Idle = 0,
    Running = 1,
    Jumping = 2,
    Falling = 3,
    Sliding = 4,
    Dead = 5
}
public class catController : MonoBehaviour
{

    public Rigidbody2D rig;
    public Animator anim;
    public BoxCollider2D boxCollider;
    public States state;
    public LayerMask groundLayer;
    float horizontalInput;
    //bool goingLeft = false;
    //bool goingRight = false;

    float jumpVerticalPushOff = 3;
    Vector2 savedlocalScale;


    float horizonatlSpeed = 5;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        savedlocalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxisRaw("Horizontal");
        // what do the below lines do ?
        if (horizontalInput > 0.001f)
        {
            transform.localScale = new Vector2(savedlocalScale.x, savedlocalScale.y);
        }
        else if (horizontalInput < -0.001f)
        {
            transform.localScale = new Vector2(-savedlocalScale.x, savedlocalScale.y);
        }
         
        if (state == States.Idle)
        {
            rig.velocity = new Vector2(0, 0);

            if (Input.GetKey(KeyCode.Space))
            {
                rig.velocity = new Vector2(0, 2);
                state = States.Jumping;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                state = States.Running;
                rig.velocity = new Vector2(1.5f, 0);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                state = States.Running;
                rig.velocity = new Vector2(-1.5f, 0);
            }
        }

        if (state == States.Running)
        {
            if (Input.GetKeyUp(KeyCode.A))
            {
                state = States.Idle;
            
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                state = States.Idle;
            
            }

        }
        else if (state == States.Jumping)
        {
            if(transform.position.y > 2)
            {
                state = States.Falling;
            }
        }
        else if (state == States.Sliding)
        {
            //If moving and left shift is not pressed then run
            //it no input idle

        }
        else if (state == States.Falling)
        {
            rig.velocity = new Vector2(0, -2);

            if(transform.position.y < 0)
            {
                state = States.Idle;
            }
        }

        else if (state == States.Dead)
        {
        }

        rig.velocity = new Vector2(horizontalInput * horizonatlSpeed, rig.velocity.y);

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
