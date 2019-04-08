using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_Model : MonoBehaviour
{
    // Start is called before the first frame update
    public ControlObj_Controller control_obj;
    public ControlObj_Model control_obj_m;
    public int node_num;
    
    public bool node_on_obj { get; set; }

    private void Awake()
    {
        control_obj = transform.parent.GetComponentInParent<ControlObj_Controller>();
        control_obj_m = transform.parent.GetComponentInParent<ControlObj_Model>();
        node_num = control_obj_m.nodes.IndexOf(this);
    }
}
