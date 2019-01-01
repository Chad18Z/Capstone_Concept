using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;

/// <summary>
/// This script manages the behavior of the grapples
/// </summary>
public class Grapple : MonoBehaviour
{
    #region fields
    // Declare a states enum
    GrappleStates state = new GrappleStates();

    // Declare and initialize a controller source (left hand or right hand)
    // Left hand is default
    SteamVR_Input_Sources source = SteamVR_Input_Sources.LeftHand;
    #endregion

    #region properties
    /// <summary>
    /// Allows the player script to assign either left or right handed device to the grapple
    /// </summary>
    public SteamVR_Input_Sources GetSource
    {
        get { return source; }
        set { source = value; }
    }
    #endregion

    #region methods
    /// <summary>
    /// Initialize
    /// </summary>
    private void Start()
    {
        // Delegate HandleTriggerPress method to the PRESS event
        EventManager.AddTriggerPressListener(HandleTriggerPress);

        // Delegate HandleTriggerRelease method to the RELEASE event
        EventManager.AddTriggerReleaseListener(HandleTriggerRelease);
    }

    /// <summary>
    /// Handles the trigger press
    /// </summary>
    /// <param name="device"></param>
    void HandleTriggerPress(SteamVR_Input_Sources controller)
    {
        if (controller == source) // test code
        {
            Debug.Log(controller + "Pressed!");
        }     
    }

    /// <summary>
    /// Handles the trigger releases
    /// </summary>
    /// <param name="controller"></param>
    void HandleTriggerRelease(SteamVR_Input_Sources controller)
    {
        if (controller == source) // test code
        {
            Debug.Log(controller + "Released!");
        }
    }
    #endregion
}
