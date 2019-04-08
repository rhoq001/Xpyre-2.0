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
            controlobj_model.curr_node_index = controlobj_model.curr_control_node.node_num;
            controlobj_model.can_accept_control = true;
        }
        else
        {
            controlobj_model.curr_control_node = null;
            controlobj_model.curr_node_index = -1;
            controlobj_model.can_accept_control = false;
        }
        
    }

    public void Rotate()
    {
        if (controlobj_model.curr_control_node && controlobj_model.canRotate)
        {
            transform.Rotate(controlobj_model.rotationAxis, controlobj_model.m_Input.MoveInput.x * controlobj_model.rotationSpeed * Time.deltaTime, Space.World);
        }
    }

    public void Movement()
    {
        if(!(controlobj_model.movement == Vector3.zero))
        {
            controlobj_model.objRigidbody.AddForce(controlobj_model.movement*controlobj_model.m_Input.MoveInput.y*controlobj_model.moveSpeed*Time.deltaTime);
        }
    }

    public void TakeControl()
    {
        if (controlobj_model.m_Input.PassControlInput && controlobj_model.can_accept_control)
        {
            Vector3 setPos = new Vector3(controlobj_model.curr_control_node.transform.localPosition.x, 0f, controlobj_model.curr_control_node.transform.localPosition.z);
            setPos.y = (transform.lossyScale.y / 2) + (controlobj_model.player.lossyScale.y / 2);

            controlobj_model.is_controlled = true;
            controlobj_model.player.rotation = transform.rotation;
            controlobj_model.player.parent = transform;

            controlobj_model.player.localPosition = setPos;

            ScaleAttached();
            controlobj_model.objRigidbody.isKinematic = false;
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
            controlobj_model.objRigidbody.isKinematic = true;
        }
        
    }

    public void MovePlayerNode()
    {
        int index_shift = controlobj_model.m_Input.ShiftNodePos;
        if(index_shift != 0)
        {
            Vector3 setPos = new Vector3(controlobj_model.curr_control_node.transform.localPosition.x, 0f, controlobj_model.curr_control_node.transform.localPosition.z);
            setPos.y = (transform.lossyScale.y / 2) + (controlobj_model.player.lossyScale.y / 2);

            controlobj_model.curr_node_index = controlobj_model.curr_node_index + index_shift;

            if (controlobj_model.curr_node_index < 0)
            {
                controlobj_model.curr_node_index = controlobj_model.nodes.Count - 1;
            }
            else if (controlobj_model.curr_node_index > controlobj_model.nodes.Count - 1)
            {
                controlobj_model.curr_node_index = 0;
            }
            controlobj_model.curr_control_node = controlobj_model.nodes[controlobj_model.curr_node_index];
            controlobj_model.player.localPosition = setPos;
        }
    }

    private void ScaleAttached()
    {
        Vector3 b = transform.lossyScale;
        controlobj_model.player.localScale = new Vector3(1f/b.x, 1f/b.y, 1f/b.z);
    }

}
