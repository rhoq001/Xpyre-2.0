using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    protected Vector2 m_Movement;
    protected Vector2 m_ArrowMovement;
    protected Vector2 m_Camera;
    protected KeyCode m_space;
    // protected float m_Jump; // made for future jump mechanic

    public Vector2 MoveArrowInput
    {
        get
        {
            return m_ArrowMovement;
        }
    }
    
    public Vector2 MoveInput
    {
        get
        {
            return m_Movement;
        }
    }

    public Vector2 CameraInput
    {
        get
        {
            return m_Camera;
        }
    }

    public bool PassControlInput
    {
        get
        {
            return Input.GetKeyDown(KeyCode.E);
        }
    }

    public bool ControlBackToPlayerInput
    {
        get
        {
            return Input.GetKeyDown(KeyCode.Q);
        }
    }

    public bool JumpInput
    {
        get
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
    }

    //public float JumpInput
    //{
    //    get
    //    {
    //        return m_Jump;
    //    }
    //}

    void Update()
    {
        m_Movement.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        m_Camera.Set(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }
}