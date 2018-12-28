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

    #endregion

    #region methods


    /// <summary>
    /// Initialize
    /// </summary>
    private void Start()
    {
        EventManager.AddTriggerPressListener(HandleTriggerPress);
    }

    /// <summary>
    /// Handles the trigger press
    /// </summary>
    /// <param name="device"></param>
    void HandleTriggerPress(SteamVR_Input_Sources device)
    {
        Debug.Log("Invoked!");
    }
    #endregion

}
