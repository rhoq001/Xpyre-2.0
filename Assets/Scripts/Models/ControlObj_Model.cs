using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlObj_Model : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerInput m_Input;
    //public Rigidbody objRigidBody;
    public Transform player;

    public List<Node_Model> nodes;
    public Node_Model curr_control_node;

    public MeshRenderer mesh;
    public Material uncontrolled_material;
    public Material controlled_material;

    public float rotationSpeed;
    public float moveSpeed;

    public bool canRotate;
    public Vector3 movement;

    public bool can_accept_control { get; set; }
    public bool is_controlled { get; set; }

    private void Awake()
    {
        Transform node_list = transform.Find("Node_List");
        foreach (Transform child in node_list)
        {
            nodes.Add(child.GetComponent<Node_Model>());
        }
        mesh = GetComponent<MeshRenderer>();
        uncontrolled_material = mesh.material;
        controlled_material = player.GetComponent<MeshRenderer>().material;
        curr_control_node = null;
        m_Input = GameObject.FindObjectOfType<Xpyre_Application>().controller.GetComponent<PlayerInput>();
        is_controlled = false;
        can_accept_control = false;
    }
}
