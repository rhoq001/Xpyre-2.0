using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    private Node_Model node_model { get; set; }
    private Node_View node_view { get; set; }

    private void Awake()
    {
        node_model = GetComponent<Node_Model>();
        node_view = GetComponent<Node_View>();
    }
}
