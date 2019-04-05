using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear_View : MonoBehaviour
{
    // Start is called before the first frame update
    private Gear_Controller gear_controller { get; set; }
    private Gear_Model gear_model { get; set; }

    private void Awake()
    {
        gear_controller = GetComponent<Gear_Controller>();
        gear_model = GetComponent<Gear_Model>();
    }

    private void Update()
    {
        if (gear_model.is_controlled)
        {
            gear_controller.Movement();
            gear_controller.ReleaseControl();
        }
        gear_controller.TakeControl();
        
    }
}
