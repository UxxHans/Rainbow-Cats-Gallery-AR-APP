using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A scriptable Object that defines the format to store the information of an artwork.
/// </summary>

[CreateAssetMenu(fileName = "Artwork", menuName = "Create Artwork", order = 1)]
public class Artwork : ScriptableObject
{
    [Header("Basic Information")]
    public string id;
    public string title;
    public string subtitle;
    public string gallery;
    public string author;
    [TextArea] public string brief;
    [TextArea] public string description;

    [Header("Images & Visual")]
    public Sprite thumbnail;
    public Texture2D ARImageTarget;

    //Images that creates the effect of depth by stacking layers of images.
    [Header("Parallax Effect")]
    public Vector2 parallaxLayerSize = Vector2.one;
    public List<Sprite> parallaxLayers;

    /// <summary>
    /// Show warning if there are too many parallax layers which may cause overflow in camera vision
    /// </summary>
    public void Awake() { 
        if (parallaxLayers.Count >= 5) 
            Debug.LogWarning("Artwork " + id + " have over 5 parallax layers, consider reducing layer counts."); 
    }
}
