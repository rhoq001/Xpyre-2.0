using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    private JumpPad_Model jump_model { get; set; }
    private JumpPad_View jump_view { get; set; }

    private void Awake()
    {
        jump_model = GetComponent<JumpPad_Model>();
        jump_view = GetComponent<JumpPad_View>();
    }

    // Update is called once per frame
    public void OnJumpPad()
    {
        jump_model.playerRigidbody.AddForce(jump_model.JumpDirection * jump_model.jump_force * Time.deltaTime, ForceMode.Impulse);
    }
}
