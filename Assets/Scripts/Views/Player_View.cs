using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_View : MonoBehaviour
{
    // Start is called before the first frame update
    private Player_Model p_model { get; set; }
    private Player_Controller p_controller { get; set; }

    private void Awake()
    {
        p_model = GetComponent<Player_Model>();
        p_controller = GetComponent<Player_Controller>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            p_controller.OnGroundHit(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            p_controller.OnGroundHit(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Control_Node") && p_model.is_controlled)
        {
            p_controller.OnControlNode(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Control_Node") && p_model.is_controlled)
        {
            p_controller.OnControlNode(false);
        }
    }

    private void Update()
    {
        if (p_model.is_controlled)
        {
            p_controller.Movement();
            p_controller.Jump();
            p_controller.ReleaseControl();
        }
        p_controller.TakeControl();
        
    }

}
