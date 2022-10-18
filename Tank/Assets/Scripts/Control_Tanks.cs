using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof (Rigidbody))]
public class Control_Tanks : MonoBehaviour
{
    [Header("Movement")]
    public string inputID;
    public float speed = 10.0f;
    public float turnSpeed = 20f;
    private float HorizontalInput;
    private float forwardInput;
    Rigidbody Player_Rb;

    [Header("Health")]
    public int health = 3;
    public int blood = 0;

    [Header("Ground Check")]
    public float playerHeight;
    public float groundDrag;
    public LayerMask whatIsGround;
    private bool grounded;

    [Header("Particle")]
    GameManager GM;
    public ParticleSystem explosionParticle;

    void Start()
    {
        Player_Rb = GetComponent<Rigidbody>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

 
    void Update()
    {

        Move_Input();
        Ground_Drag();
        Speed_Control();
    }

    void Move_Input()
    {
        HorizontalInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);

        Player_Rb.AddForce(transform.forward * speed * forwardInput);

        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * HorizontalInput);
    }

    void Ground_Drag()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        //Debug.DrawRay(transform.position , Vector3.down, Color.black, playerHeight * 0.5f + 0.2f);

        // handle drag

        if (grounded)
            Player_Rb.drag = groundDrag;
        else
            Player_Rb.drag = 0;
    }

    void Speed_Control()
    {
        Vector3 flatVel = new Vector3(Player_Rb.velocity.x, 0, Player_Rb.velocity.z);

        if (flatVel.magnitude > speed)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            Player_Rb.velocity = new Vector3(limitedVel.x, Player_Rb.velocity.y, limitedVel.z);
        }
    }

  
    void destroyTank()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        blood++;
        if (collision.gameObject.CompareTag("Bullet") && blood == health)
        {
            Instantiate(explosionParticle, collision.transform.position, explosionParticle.transform.rotation);
            GM.Start_End();
            Destroy(gameObject);
        }
    }

}
