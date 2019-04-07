using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    private Player_Model p_model { get; set; }
    private Player_View p_view { get; set; }

    private void Awake()
    {
        p_model = GetComponent<Player_Model>();
        p_view = GetComponent<Player_View>();
    }
    public void OnControlNode(bool onControl)
    {
       p_model.can_pass_control = onControl;
    }

    public void Movement()
    {
        float horizontal = p_model.m_Input.MoveInput.x;
        float vertical = p_model.m_Input.MoveInput.y;

        p_model.flat_cam_direction = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z);
        p_model.movement = ((vertical * p_model.flat_cam_direction) + (horizontal * Camera.main.transform.right)) * Time.deltaTime;
        p_model.movement = p_model.movement.normalized * p_model.physics_speed * Time.deltaTime;

        p_model.playerRigidbody.AddForce(p_model.movement * p_model.physics_speed_coefficient);
    }

    public void TakeControl()
    {
        if (p_model.m_Input.ControlBackToPlayerInput && !p_model.is_controlled)
        {
            p_model.is_controlled = true;
            p_model.playerRigidbody.isKinematic = false;
            p_model.mesh.enabled = true;
        }

    }

    public void ReleaseControl()
    {
        if (p_model.m_Input.PassControlInput && p_model.can_pass_control)
        {
            p_model.is_controlled = false;
            p_model.playerRigidbody.isKinematic = true;
            p_model.mesh.enabled = false;
        }

    }

    public void Jump()
    {
        if(p_model.m_Input.JumpInput && p_model.onGround)
        {
            Vector3 jump = new Vector3(0, p_model.jump_force, 0);
            p_model.playerRigidbody.AddForce(jump, ForceMode.Impulse);
        }
    }

    public void OnGroundHit(bool OnGround)
    {
        p_model.onGround = OnGround;
    }
    //playerRigidbody.MovePosition(transform.position + movement);

}

