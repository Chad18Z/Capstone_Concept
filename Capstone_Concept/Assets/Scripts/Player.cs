using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

/// <summary>
/// Player script
/// </summary>
public class Player : MonoBehaviour
{
    #region fields
    // Reference to grapple prefab
    [SerializeField]
    GameObject grapplePrefab;

    // References to each grapple 
    GameObject leftGrapple;
    GameObject rightGrapple;
    #endregion

    #region methods
    // Start is called before the first frame update
    void Start()
    {
        // Instantiate two grapples - Make them children of the player object
        leftGrapple = Instantiate(grapplePrefab, transform);
        rightGrapple = Instantiate(grapplePrefab, transform);

        // Assign left controller to left grapple
        leftGrapple.GetComponent<Grapple>().GetSource = SteamVR_Input_Sources.LeftHand;

        // Assign right controller to right grapple
        rightGrapple.GetComponent<Grapple>().GetSource = SteamVR_Input_Sources.RightHand;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
}
