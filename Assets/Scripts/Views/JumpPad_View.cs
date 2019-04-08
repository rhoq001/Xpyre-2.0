using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad_View : MonoBehaviour
{
    private JumpPad_Model jump_model { get; set; }
    private JumpPad_Controller jump_controller { get; set; }

    private void Awake()
    {
        jump_model = GetComponent<JumpPad_Model>();
        jump_controller = GetComponent<JumpPad_Controller>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        jump_controller.OnJumpPad();
    }
}
