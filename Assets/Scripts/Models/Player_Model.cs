using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Model : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody playerRigidbody;
    public PlayerInput m_Input;


    public Vector3 movement;
    // Vector3 JumpForce; // Normalized jump direction
    public Vector3 flat_cam_direction;
    

    public float physics_speed;
    public float physics_speed_coefficient;

    public float line_speed;
    public float jump_force;

    public bool is_controlled;
    public bool can_pass_control;
    public bool is_attached;



    //References
    // Line current_line;
    // Node current_node;

}

