using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_Model : MonoBehaviour
{
    // Start is called before the first frame update
    public Gear_Controller gear;

    private void Awake()
    {
        gear = GetComponentInParent<Gear_Controller>();
    }
}
