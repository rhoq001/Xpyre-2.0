using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Xpyre_Element : MonoBehaviour
{
    public Xpyre_Application app { get { return GameObject.FindObjectOfType<Xpyre_Application>(); } }
}


public class Xpyre_Application : MonoBehaviour
{
    // Start is called before the first frame update
    public Xpyre_Model model;
    public Xpyre_View view;
    public Xpyre_Controller controller;

}