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
    // provide delegates that will handle triggerPress events
    static List<UnityAction<SteamVR_Input_Sources>> triggerPressListeners = new List<UnityAction<SteamVR_Input_Sources>>();


    // Create a list that will hold all invokers for the triggerRelease event
    // Invokers for this event will be the PlayerInput script
    static List<PlayerInput> triggerReleaseInvokers = new List<PlayerInput>();

    // Create a list that will hold all of the listeners for the triggerRelease event
    // provide delegates that will handle triggerRelease events
    static List<UnityAction<SteamVR_Input_Sources>> triggerReleaseListeners = new List<UnityAction<SteamVR_Input_Sources>>();
    #endregion


    #region trigger press event methods

    /// <summary>
    /// Add invoker for the triggerpress event to the invoker list
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddTriggerPressInvoker(PlayerInput invoker)
    {
        triggerPressInvokers.Add(invoker); // add the provided invoker to the list of invokers

        // Add all listeners to the invoker
        foreach(UnityAction<SteamVR_Input_Sources> listener in triggerPressListeners)
        {
            invoker.AddTriggerPressListener(listener);
        }
    }
    /// <summary>
    /// Adds the given handler as a listener
    /// </summary>
    /// <param name="handler"></param>
    public static void AddTriggerPressListener(UnityAction<SteamVR_Input_Sources> handler)
    {
        triggerPressListeners.Add(handler); // Add listener to the list of listeners

        // Add this listener to all triggerpress invokers
        foreach(PlayerInput playerInput in triggerPressInvokers)
        {
            playerInput.AddTriggerPressListener(handler);
        }
    }
    #endregion

    #region trigger release event methods
    /// <summary>
    /// Add invoker for the trigger release event to the invoker list
    /// </summary>
    /// <param name="invoker"></param>
    public static void AddTriggerReleaseInvoker(PlayerInput invoker)
    {
        triggerReleaseInvokers.Add(invoker); // add the provided invoker to the list of invokers

        // Add all listeners to the invoker
        foreach (UnityAction<SteamVR_Input_Sources> listener in triggerReleaseListeners)
        {
            invoker.AddTriggerReleaseListener(listener);
        }
    }
    /// <summary>
    /// Adds the given handler as a listener for the trigger release event
    /// </summary>
    /// <param name="handler"></param>
    public static void AddTriggerReleaseListener(UnityAction<SteamVR_Input_Sources> handler)
    {
        triggerReleaseListeners.Add(handler); // Add listener to the list of listeners

        // Add this listener to all triggerpress invokers
        foreach (PlayerInput playerInput in triggerReleaseInvokers)
        {
            playerInput.AddTriggerReleaseListener(handler);
        }
    }
    #endregion

}
