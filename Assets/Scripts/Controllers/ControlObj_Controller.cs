using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlObj_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    private ControlObj_Model controlobj_model { get; set; }
    private ControlObj_View controlobj_view { get; set; }

    private void Awake()
    {
        controlobj_view = GetComponent<ControlObj_View>();
        controlobj_model = GetComponent<ControlObj_Model>();
    }

    public void PlayerOnControl(bool OnControl, Node_Model new_node)
    {
        if (OnControl && new_node)
        {
            controlobj_model.curr_control_node = new_node;
            controlobj_model.can_accept_control = true;
        }
        else
        {
            controlobj_model.curr_control_node = null;
            controlobj_model.can_accept_control = false;
        }
        
    }

    public void Rotate()
    {
        if (controlobj_model.curr_control_node && controlobj_model.canRotate)
        {
            transform.RotateAround(controlobj_model.curr_control_node.transform.position, transform.up, controlobj_model.m_Input.MoveInput.x * controlobj_model.rotationSpeed * Time.deltaTime);
        }
    }

    public void Movement()
    {
        if(!(controlobj_model.movement == Vector3.zero))
        {
            controlobj_model.transform.Translate(controlobj_model.movement*controlobj_model.m_Input.MoveInput.y*controlobj_model.moveSpeed, Space.World);
        }
    }

    public void TakeControl()
    {
        if (controlobj_model.m_Input.PassControlInput && controlobj_model.can_accept_control)
        {
            controlobj_model.is_controlled = true;
            controlobj_model.player.rotation = transform.rotation;
            controlobj_model.player.parent = transform;
            ScaleAttached();
            controlobj_model.mesh.material = controlobj_model.controlled_material;
        }
        
    }

    public void ReleaseControl()
    {
        if (controlobj_model.m_Input.ControlBackToPlayerInput)
        {
            controlobj_model.is_controlled = false;
            controlobj_model.player.parent = null;
            controlobj_model.mesh.material = controlobj_model.uncontrolled_material;
        }
        
    }

    private void ScaleAttached()
    {
        Vector3 b = transform.lossyScale;
        controlobj_model.player.localScale = new Vector3(1f/b.x, 1f/b.y, 1f/b.z);
    }

}
