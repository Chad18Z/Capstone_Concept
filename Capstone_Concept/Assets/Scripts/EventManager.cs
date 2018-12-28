using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;

/// <summary>
/// The event system
/// </summary>
public static class EventManager 
{
    #region fields
    // Create a list that will hold all invokers for the triggerPress event
    // Invokers for this event will be the PlayerInput script
    static List<PlayerInput> triggerPressInvokers = new List<PlayerInput>();

    // Create a list that will hold all of the listeners for the triggerPress event
    // Grapple script will provide delegates that will handle triggerPress events
    static List<UnityAction<SteamVR_Input>> triggerPressListeners = new List<UnityAction<SteamVR_Input>>();
    #endregion

    #region properties
    #endregion

    #region methods

    /// <summary>
    /// Add invoker for the triggerpress event to the invoker list
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddTriggerPressInvoker(PlayerInput invoker)
    {
        triggerPressInvokers.Add(invoker); // add the provided invoker to the list of invokers

        // Add all listeners to the invoker
        foreach(UnityAction<SteamVR_Input> listener in triggerPressListeners)
        {
            invoker.AddListener(listener);
        }
    }
    #endregion

}
