using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach the script to the preview parallax parent
/// It will position the parent according to the value
/// </summary>
public class UserArtworkParallaxZoom : MonoBehaviour
{
    /// <summary>
    /// This function set the position within max and min accoring to the given value
    /// </summary>
    /// <param name="value">A float from 0 - 1 that can define the close and far position</param>
    public void SetPosition(float value)
    {
        transform.localPosition = new Vector3(0, 0, 0.05f + value * 0.25f);
    }
}
