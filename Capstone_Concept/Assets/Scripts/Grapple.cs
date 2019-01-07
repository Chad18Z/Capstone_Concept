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

    // Reference to other grapple's script
    // This will allow this grapple to know the state of the other grapple and vice-versa
    Grapple otherGrapple;

    // Reference to root controller. We need this for raycasting.
    Transform rootTransform;

    // Reference to a line renderer that will be used to draw the grapple line
    LineRenderer grappleLine;

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
    /// <summary>
    /// Allows the other grapple (or any other object) to know this grapple's state
    /// </summary>
    public GrappleStates GetState
    {
        get { return state; }
    }
    /// <summary>
    /// This property allows the player script to provide this grapple a reference to the other grapple
    /// </summary>
    public Grapple OtherGrapple
    {
        set
        {
            otherGrapple = value;
        }
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

        // Get the reference to root controller: This grapples grandparent
        rootTransform = gameObject.transform.parent.parent;

        // Get reference to the line renderer that's attached to this grapple gameobject
        grappleLine = GetComponent<LineRenderer>();

        // Set state to default (IDLE)
        state = GrappleStates.IDLE;

        // Turn line renderer off
        grappleLine.enabled = false;
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
            TriggerPress();          
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
            TriggerRelease();
        }
    }
    /// <summary>
    /// Sequence of actions to take when the player releases the trigger on a controller
    /// </summary>
    void TriggerRelease()
    {
        switch (state)
        {
            case (GrappleStates.LOCKED):
                ReleaseGrapple();
                break;

            case (GrappleStates.DEPLOYED):
                return;

            case (GrappleStates.IDLE):
                return;

            default:
                return;
        }
    }
    /// <summary>
    /// Removes the grapple from its anchorpoint on the ceiling
    /// </summary>
    void ReleaseGrapple()
    {
        state = GrappleStates.IDLE;
        grappleLine.enabled = false;
    }
    /// <summary>
    /// Sequence of actions to take when the player presses the trigger on a controller
    /// </summary>
    void TriggerPress()
    {
        switch (state)
        {
            case (GrappleStates.IDLE):
                GrappleTarget();
                break;

            case (GrappleStates.DEPLOYED):
                return;

            default:
                return;
        }
    }
    /// <summary>
    /// Sends grapple hook to the ceiling
    /// </summary>
    /// <returns></returns>
    void GrappleTarget()
    {
        // Set this grapple's state to LOCKED
        state = GrappleStates.LOCKED;

        // Enable the line renderer
        grappleLine.enabled = true;

        // Draw line from grapple to anchorpoint
        DrawGrappleLine();
    }
    /// <summary>
    /// Renders the line between the grapple and the anchorpoint on the ceiling
    /// </summary>
    void DrawGrappleLine()
    {
        grappleLine.SetPosition(0, rootTransform.position);
        grappleLine.SetPosition(1, rootTransform.position + rootTransform.forward * 100);
    }
    /// <summary>
    /// Make the grapple behave according to its state
    /// </summary>
    private void Update()
    {
        switch (state)
        {
            case GrappleStates.LOCKED:
                DrawGrappleLine();
                break;

            case GrappleStates.IDLE:
                return;

            default:
                return;
        }
    }
    #endregion
}
