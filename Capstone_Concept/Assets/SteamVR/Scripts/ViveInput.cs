using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ViveInput : MonoBehaviour
{
    public SteamVR_Input_Sources thisHand;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SteamVR_Input._default.inActions.Teleport.GetStateUp(thisHand)) 
        {
            Debug.Log("Pressed");
        }
    }
}
