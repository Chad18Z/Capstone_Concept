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
    protected TriggerPressEvent triggerPressEvent = new TriggerPressEvent();
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

    private void Update()
    {
        if (Input.anyKey)
        {
            triggerPressEvent.Invoke(new SteamVR_Input());
        }
    }
    /// <summary>
    /// Adds a listener to the trigger press event
    /// </summary>
    /// <param name="handler"></param>
    public void AddListener(UnityAction<SteamVR_Input> handler)
    {
        triggerPressEvent.AddListener(handler);
    }
    #endregion

}
