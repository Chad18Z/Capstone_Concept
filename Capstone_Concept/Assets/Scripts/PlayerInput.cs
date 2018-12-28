using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;

/// <summary>
/// Captures input from the VR controllers and invokes events accordingly
/// This scripts captures input from ALL controllers
/// </summary>
public class PlayerInput : MonoBehaviour
{
    #region fields
    // Create a new trigger press event
    TriggerPressEvent triggerPressEvent = new TriggerPressEvent();

    // Reference to a SteamVR controller
    public SteamVR_Input_Sources input = SteamVR_Input_Sources.LeftHand;
    #endregion

    #region properties
    #endregion

    #region methods

    /// <summary>
    /// Initialize 
    /// </summary>
    private void Start()
    {
        // Add this script as an invoker for the trigger press event
        EventManager.AddTriggerPressInvoker(this);

    }

    /// <summary>
    /// Check for input from controllers (TESTING PHASE)
    /// </summary>
    private void Update()
    {
        if (SteamVR_Input._default.inActions.InteractUI.GetStateUp(input))
        {
            triggerPressEvent.Invoke(input);

        }
    }
    /// <summary>
    /// Adds a listener to the trigger press event
    /// </summary>
    /// <param name="handler"></param>
    public void AddListener(UnityAction<SteamVR_Input_Sources> handler)
    {
        triggerPressEvent.AddListener(handler);
    }
    #endregion

}
