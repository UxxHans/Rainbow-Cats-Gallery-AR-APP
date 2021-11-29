using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Send Load and save artwork library calls. 
/// Manipulate user artwork library UI elements.
/// Translate artworkID from the save data to detailed instance.
/// </summary>
public class UserArtworkLibraryManager : MonoBehaviour
{
    public GameObject artworkPanel;
    public GameObject artworkThumbnail;
    public Transform artworkThumbnailGrid;
    public ImageParallaxEffect artworkPreviewParallax;

    List<Artwork> userArtworkLibrary = new List<Artwork>();
    Artwork currentArtwork;

    /// <summary>
    /// Initialize the artwork library
    /// </summary>
    private void Start()
    {
        LoadUserArtworkLibrary();
        UpdateThumbnailList();
    }

    /// <summary>
    /// Load the artwork from save file and translate it to artwork class from artwork library.
    /// </summary>
    void LoadUserArtworkLibrary()
    {
        //Clear the owned artworks ID list
        userArtworkLibrary.Clear();
        //Get list of all owned artworks ID.
        List<string> artworksOwnedList = FindObjectOfType<SaveManager>().GetArtworksOwned();
        //Get artwork instance from the library and add to the current list.
        foreach (string artworkOwned in artworksOwnedList) userArtworkLibrary.Add(FindObjectOfType<ArtworkLibrary>().GetArtwork(artworkOwned));
    }

    /// <summary>
    /// Spawn and setup the thumbnails in the grid layout group.
    /// </summary>
    void UpdateThumbnailList()
    {
        //Clean the UI in the list
        foreach (Transform child in artworkThumbnailGrid) Destroy(child.gameObject);

        //Spawn thumbnails in the grid
        foreach(Artwork artwork in userArtworkLibrary)
        {
            //Setup UI values
            GameObject instance = Instantiate(artworkThumbnail, artworkThumbnailGrid);
            UserArtworkLibraryThumbnailUI instanceUI = instance.GetComponent<UserArtworkLibraryThumbnailUI>();
            instanceUI.thumbnail.sprite = artwork.thumbnail;
            instanceUI.title.text = artwork.title;
            instanceUI.author.text = artwork.author;
            instanceUI.gallery.text = artwork.gallery;

            //Setup button listener
            instanceUI.select.onClick.AddListener(delegate
            {
                //Set the current artwork
                currentArtwork = artwork;

                //Setup artwork preview
                artworkPreviewParallax.SetupParallaxLayers(artwork);

                //Display the panel
                artworkPanel.SetActive(true);
                UserArtworkLibraryPanelUI panelUI = artworkPanel.GetComponent<UserArtworkLibraryPanelUI>();

                //Setup UI values
                panelUI.title.text = artwork.title;
                panelUI.subtitle.text = artwork.subtitle;
                panelUI.gallery.text = artwork.gallery;
                panelUI.author.text = artwork.author;
                panelUI.brief.text = artwork.brief;
                panelUI.description.text = artwork.description;

                //Setup button listener
                panelUI.delete.onClick.AddListener(delegate 
                { 
                    //Remove artwork from save data
                    RemoveArtwork(currentArtwork.id);
                    //Hide the panel
                    artworkPanel.SetActive(false);
                    //Refresh the list
                    UpdateThumbnailList();
                });
            });
        }
    }

    /// <summary>
    /// This function calls the save manager to do remove the artwork from save data.
    /// </summary>
    /// <param name="artworkID">The ID of the artwork to delete</param>
    public void RemoveArtwork(string artworkID) 
    { 
        FindObjectOfType<SaveManager>().RemoveArtwork(artworkID);
        LoadUserArtworkLibrary();
        UpdateThumbnailList();
    }

    /// <summary>
    /// This function calls the save manager to add the artwork to save data.
    /// </summary>
    /// <param name="artworkID">The ID of the artwork to add</param>
    public bool AddArtwork(string artworkID)
    {
        bool success = FindObjectOfType<SaveManager>().AddArtwork(artworkID);
        //If the artwork is already saved
        if (!success) return false;

        //Else update the library
        LoadUserArtworkLibrary();
        UpdateThumbnailList();
        return true;
    }
    
}
