using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_View : MonoBehaviour
{
    // Start is called before the first frame update
    private Node_Controller node_controller { get; set; }
    private Node_Model node_model { get; set; }

    private void Awake()
    {
        node_controller = GetComponent<Node_Controller>();
        node_model = GetComponent<Node_Model>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            node_model.control_obj.PlayerOnControl(true, node_model);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            node_model.control_obj.PlayerOnControl(false, null);
        }
    }
}
