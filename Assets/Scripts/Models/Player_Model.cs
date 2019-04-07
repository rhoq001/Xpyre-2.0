using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Model : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody playerRigidbody;
    public PlayerInput m_Input;
    public MeshRenderer mesh;

    public Vector3 movement { get; set; }
    // Vector3 JumpForce; // Normalized jump direction
    public Vector3 flat_cam_direction { get; set; }
    

    public float physics_speed;
    public float physics_speed_coefficient;

    public float line_speed;
    public float jump_force;

    public bool is_controlled { get; set; }
    public bool can_pass_control { get; set; }
    public bool is_attached { get; set; }
    public bool onGround { get; set; }


    private void Awake()
    {
        m_Input = GameObject.FindObjectOfType<Xpyre_Application>().controller.GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        mesh = GetComponent<MeshRenderer>();

        is_controlled = true;
        can_pass_control = false;
        is_attached = false;
        onGround = false;
    }
    //References
    // Line current_line;
    // Node current_node;

}

