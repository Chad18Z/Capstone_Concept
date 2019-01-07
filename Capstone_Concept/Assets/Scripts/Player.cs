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
    // Reference to grapple prefabs
    [SerializeField]
    GameObject rightGrapplePrefab;

    [SerializeField]
    GameObject leftGrapplePrefab;

    // References to each grapple 
    GameObject leftGrapple;
    GameObject rightGrapple;

    // Refeerence to each grapple's script
    Grapple left;
    Grapple right;
    #endregion

    #region methods
    // Start is called before the first frame update
    void Start()
    {
        // Instantiate two grapples - Make them children of each controller respectively
        leftGrapple = Instantiate(leftGrapplePrefab, GameObject.FindGameObjectWithTag("leftController").transform);
        rightGrapple = Instantiate(rightGrapplePrefab, GameObject.FindGameObjectWithTag("rightController").transform);

        // Get references to grapple scripts
        left = leftGrapple.GetComponent<Grapple>();
        right = rightGrapple.GetComponent<Grapple>();

        // Assign left controller to left grapple
        left.GetSource = SteamVR_Input_Sources.LeftHand;

        // Assign the right controller as the OTHER controller
        left.OtherGrapple = right;
      
        // Assign right controller to right grapple
        right.GetSource = SteamVR_Input_Sources.RightHand;

        // Assign the left controller as the OTHER controller
        right.OtherGrapple = left;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
}
