using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach the script to the preview parallax parent
/// It will rotate the parent according to the value
/// </summary>
public class UserArtworkParallaxRotator : MonoBehaviour
{
    /// <summary>
    /// This function set the rotation within max and min accoring to the given value
    /// </summary>
    /// <param name="value">A float from 0 - 1 that can define the left and right rotation</param>
    public void SetRotation(float value)
    {
        transform.eulerAngles = new Vector3(0, -22.5f + value * 45, 0);
    }
}
