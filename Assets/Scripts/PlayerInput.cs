using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    protected Vector2 m_Movement;
    protected Vector2 m_Camera;
    protected KeyCode m_space;
    // protected float m_Jump; // made for future jump mechanic


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

    public bool PassControlInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return true;
        }
        return false;
    }

    public bool ControlBackToPlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            return true;
        }
        return false;
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
        m_Movement.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        m_Camera.Set(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        m_space = KeyCode.Space;
    }
}