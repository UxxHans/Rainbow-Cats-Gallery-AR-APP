using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// There will be a search function and returns the list of artworks that the searched gallery have.
/// The library is totally just a demostration, it does not have the capacity to handle big data.
/// </summary>

public class ArtworkLibrary : MonoBehaviour
{
    public List<GalleryArtworks> artworkLibrary;
    List<string> allGalleries;

    public void Awake() => allGalleries = GetAllGalleries();

    /// <summary>
    /// This function returns the list of all artworks of a specific gallery.
    /// </summary>
    /// <param name="gallery">Gallery to search</param>
    /// <returns>A list of all artworks of the gallery.</returns>
    public GalleryArtworks GetGalleryArtworks(string gallery)
    {
        foreach(GalleryArtworks galleryArtworks in artworkLibrary)
        {
            if(galleryArtworks.gallery == gallery)
            {
                return galleryArtworks;
            }
        }
        Debug.LogError("Gallery artworks can not be found, no gallery matched in the library.");
        return new GalleryArtworks();
    }

    /// <summary>
    /// This function searches all artworks data and find the data that matches the ID given.
    /// </summary>
    /// <param name="artworkID">Artwork ID to search</param>
    /// <returns>Search Result that matches the ID</returns>
    public Artwork GetArtwork(string artworkID)
    {
        foreach (GalleryArtworks galleryArtworks in artworkLibrary)
        {
            foreach(Artwork artwork in galleryArtworks.artworks)
            if (artwork.id == artworkID)
            {
                return artwork;
            }
        }
        Debug.LogError("Artwork can not be found, no artworkID matched in the library.");
        return new Artwork();
    }

    /// <summary>
    /// This function searches all the galleries and returns a list of similar galleries according to the input.
    /// </summary>
    /// <param name="input">The search input</param>
    /// <returns>Searched similar galleries</returns>
    public List<string> GetGallery(string input)
    {
        List<string> galleries = new List<string>();
        foreach(string gallery in allGalleries)
        {
            //If the input string matches part of the gallery name
            if (gallery.ToLower().Contains(input.ToLower()))
            {
                //Add this gallery to the list
                galleries.Add(gallery);
            }
        }
        return galleries;
    }

    /// <summary>
    /// The function searches the library and returns a list of all galleries found.
    /// </summary>
    /// <returns>All galleries found</returns>
    public List<string> GetAllGalleries()
    {
        List<string> allGalleries = new List<string>();
        foreach (GalleryArtworks galleryArtworks in artworkLibrary)
        {
            allGalleries.Add(galleryArtworks.gallery);
        }
        return allGalleries;
    }
}
