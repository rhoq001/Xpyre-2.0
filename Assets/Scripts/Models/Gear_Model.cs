using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear_Model : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerInput m_Input;

    public Node_Model curr_control;
    public float rotationSpeed;
    public bool can_accept_control;
    public bool is_controlled;

    private void Awake()
    {
        curr_control = null;
    }
}
