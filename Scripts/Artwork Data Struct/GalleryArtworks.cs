using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A scriptable Object that defines the artworks in different galleries. 
/// </summary>

[CreateAssetMenu(fileName = "GalleryArtworks", menuName = "Create Gallery Artworks", order = 2)]
public class GalleryArtworks : ScriptableObject
{
    public string gallery;
    public List<Artwork> artworks;
}
