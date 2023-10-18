using UnityEngine;
using UnityEngine.SceneManagement;

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

    Vector2 savedlocalScale;
    private float deadTimer = .33f;
    private int currentDirection = 1;
    private float slideTimer = 1f;
    public static bool dead = false;
    float horizonatlSpeed = 5;

    private float beforeGOScreen = 2f;
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
                rig.velocity = new Vector2(0, 4);
                state = States.Jumping;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                state = States.Running;
                currentDirection = 2;
                rig.velocity = new Vector2(1.5f, 0);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                state = States.Running;
                currentDirection = 1;
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

            if(Input.GetKeyUp(KeyCode.LeftShift))
            {
                state = States.Sliding;
                slideTimer = 1f;
            }

        }
        else if (state == States.Jumping)
        {
            if(transform.position.y > 0)
            {
                state = States.Falling;
            }
        }
        else if (state == States.Sliding)
        {
            slideTimer -= Time.deltaTime;
            if (slideTimer > 0)
            {
                if (currentDirection == 1)
                {
                    rig.AddForce(new Vector2(-10, 0));
                }
                if (currentDirection == 2)
                {
                    rig.AddForce(new Vector2(10, 0));
                }
            }
            if(slideTimer < 0)
            {
                state = States.Idle;
            }

        }
        else if (state == States.Falling)
        {
            rig.velocity = new Vector2(0, -2);

            if(transform.position.y < -2.3)
            {
                state = States.Idle;
            }
        }

        else if (state == States.Dead)
        {
            deadTimer -= Time.deltaTime;
            if(deadTimer > 0)
            {
                if (crateScript.side == 1)
                {
                    rig.velocity = new Vector2(0, 6);
                    rig.AddForce(new Vector2(-4, 0));
                }
                else if(crateScript.side == 2)
                {
                    rig.velocity = new Vector2(0, 6);
                    rig.AddForce(new Vector2(4, 0));
                }
                
            }
            else if(deadTimer < 0)
            {
                if (crateScript.side == 1)
                {
                    rig.velocity = new Vector2(0, -8);
                    rig.AddForce(new Vector2(-4, 0));
                }
                else if (crateScript.side == 2)
                {
                    rig.velocity = new Vector2(0, -8);
                    rig.AddForce(new Vector2(4, 0));
                }
            }

            dead = true;

        }

        if(dead)
        {
            beforeGOScreen -= Time.deltaTime;
            if (beforeGOScreen < 0)
            {
                SceneManager.LoadScene(3);
            }
        }

        rig.velocity = new Vector2(horizontalInput * horizonatlSpeed, rig.velocity.y);

        anim.SetInteger("state", (int)state);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if(state == States.Sliding) // Player kills crate
            {
                crateScript.respawnTimer = 0;
                canvasScript.cratesDeath++;
            }
            else if(collision.tag == "Crate")
            {
                state = States.Dead;

            }
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
