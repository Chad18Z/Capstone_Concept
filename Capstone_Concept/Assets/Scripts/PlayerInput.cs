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

    // Create a new trigger release event
    TriggerReleaseEvent triggerReleaseEvent = new TriggerReleaseEvent();

    // Reference to SteamVR controllers   left and right
    public SteamVR_Input_Sources leftController = SteamVR_Input_Sources.LeftHand;
    public SteamVR_Input_Sources rightController = SteamVR_Input_Sources.RightHand;
    #endregion


    #region methods

    /// <summary>
    /// Initialize 
    /// </summary>
    private void Start()
    {
        // Add this script as an invoker for the trigger press event
        EventManager.AddTriggerPressInvoker(this);

        // Add this script as an invoker for the trigger release event
        EventManager.AddTriggerReleaseInvoker(this);

    }

    /// <summary>
    /// Check for input from controllers (TESTING PHASE)
    /// </summary>
    private void Update()
    {
        // Check for left controller trigger press
        if (SteamVR_Input._default.inActions.InteractUI.GetStateDown(leftController))
        {
            triggerPressEvent.Invoke(leftController);

        }
        // Check for left controller trigger release
        if (SteamVR_Input._default.inActions.InteractUI.GetStateUp(leftController))
        {
            triggerReleaseEvent.Invoke(leftController);

        }
        // Check for right controller trigger press
        if (SteamVR_Input._default.inActions.InteractUI.GetStateDown(rightController))
        {
            triggerPressEvent.Invoke(rightController);
        }

        //// Check for right controller trigger release
        if (SteamVR_Input._default.inActions.InteractUI.GetStateUp(rightController))
        {
            triggerReleaseEvent.Invoke(rightController);
        }
    }
    /// <summary>
    /// Adds a listener to the trigger press event
    /// </summary>
    /// <param name="handler"></param>
    public void AddTriggerPressListener(UnityAction<SteamVR_Input_Sources> handler)
    {
        triggerPressEvent.AddListener(handler);
    }

    /// Adds a listener to the trigger press event
    /// </summary>
    /// <param name="handler"></param>
    public void AddTriggerReleaseListener(UnityAction<SteamVR_Input_Sources> handler)
    {
        triggerReleaseEvent.AddListener(handler);
    }
    #endregion

}
