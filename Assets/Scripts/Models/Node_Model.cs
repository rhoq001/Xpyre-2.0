using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_Model : MonoBehaviour
{
    // Start is called before the first frame update
    public ControlObj_Controller control_obj;
    public bool node_on_obj;

    private void Awake()
    {
        control_obj = transform.parent.GetComponentInParent<ControlObj_Controller>();
    }
}
