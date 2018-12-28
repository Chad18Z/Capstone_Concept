using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;

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
    /// Adds a listener to the trigger press event
    /// </summary>
    /// <param name="handler"></param>
    public void AddListener(UnityAction<SteamVR_Input> handler)
    {
        triggerPressEvent.AddListener(handler);
    }
    #endregion

}
