using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    private Gear_Model gear_model { get; set; }
    private Gear_View gear_view { get; set; }

    private void Awake()
    {
        gear_view = GetComponent<Gear_View>();
        gear_model = GetComponent<Gear_Model>();
        gear_model.m_Input = GameObject.FindObjectOfType<Xpyre_Application>().controller.GetComponent<PlayerInput>();
        gear_model.is_controlled = false;
    }

    public void PlayerOnControl(bool onControl, Node_Model controlNode)
    {
        if (onControl)
        {
            gear_model.can_accept_control = true;
            gear_model.curr_control = controlNode;
        }
        else
        {
            gear_model.can_accept_control = false;
            gear_model.curr_control = null;
        }
        
    }

    public void Movement()
    {
        if (gear_model.is_controlled && gear_model.curr_control)
        {
            transform.RotateAround(gear_model.curr_control.transform.position, transform.up, gear_model.m_Input.MoveInput.x * gear_model.rotationSpeed * Time.deltaTime);
        }
    }

    public void TakeControl()
    {
        if (gear_model.m_Input.PassControlInput() && gear_model.can_accept_control)
        {
            gear_model.is_controlled = true;
        }
        
    }

    public void ReleaseControl()
    {
        if (gear_model.m_Input.ControlBackToPlayerInput() && gear_model.is_controlled)
        {
            gear_model.is_controlled = false;
        }
        
    }
}
