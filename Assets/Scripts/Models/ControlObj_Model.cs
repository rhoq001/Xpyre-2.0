using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlObj_Model : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerInput m_Input;
    //public Rigidbody objRigidBody;
    public Transform player;
    public Rigidbody objRigidbody;

    public List<Node_Model> nodes;
    public Node_Model curr_control_node;
    public int curr_node_index { get; set; }

    public MeshRenderer mesh;
    public Material uncontrolled_material;
    public Material controlled_material;

    public float rotationSpeed;
    public bool canRotate;
    public Vector3 rotationAxis;

    public Vector3 movement;
    public float moveSpeed;

    public bool can_accept_control { get; set; }
    public bool is_controlled { get; set; }

    private void Awake()
    {
        m_Input = GameObject.FindObjectOfType<Xpyre_Application>().controller.GetComponent<PlayerInput>();
        objRigidbody = GetComponent<Rigidbody>();

        Transform node_list = transform.Find("Node_List");
        foreach (Transform child in node_list)
        {
            nodes.Add(child.GetComponent<Node_Model>());
        }

        mesh = GetComponent<MeshRenderer>();
        controlled_material = player.GetComponent<MeshRenderer>().material;
        uncontrolled_material = mesh.material;
        
        curr_control_node = null;
        is_controlled = false;
        can_accept_control = false;
    }
}
