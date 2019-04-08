using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlObj_View : MonoBehaviour
{
    // Start is called before the first frame update
    private ControlObj_Controller controlobj_controller { get; set; }
    private ControlObj_Model controlobj_model { get; set; }

    private void Awake()
    {
        controlobj_controller = GetComponent<ControlObj_Controller>();
        controlobj_model = GetComponent<ControlObj_Model>();
    }

    private void FixedUpdate()
    {
        if (controlobj_model.is_controlled)
        {
            controlobj_controller.Rotate();
            controlobj_controller.Movement();
            controlobj_controller.MovePlayerNode();
            controlobj_controller.ReleaseControl();
        }
        controlobj_controller.TakeControl();
        
    }
}
