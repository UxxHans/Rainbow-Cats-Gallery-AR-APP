using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// This script spawns and setup gallery search options according to the input field.
/// </summary>
public class GallerySearchManager : MonoBehaviour
{
    public InputField galleryInput;
    public GameObject gallerySearchOption;
    public Transform gallerySearchOptionsGrid;
    public GameObject gallerySearchOptionsPanel;
    public Text currentGallery;

    /// <summary>
    /// Set the listener and initialize
    /// </summary>
    void Start()
    {
        //Update first time for the options
        UpdateSearchOptions();

        //Setup current empty gallery
        currentGallery.text = "No AR target loaded. Please choose your current gallery.";

        //Setup the listener
        galleryInput.onValueChanged.AddListener(delegate
        {
            UpdateSearchOptions();
        });
    }

    /// <summary>
    /// This function refresh the options according to the input.
    /// </summary>
    void UpdateSearchOptions()
    {
        //Wipe all the UI from the list
        foreach (Transform child in gallerySearchOptionsGrid) Destroy(child.gameObject);

        List<string> galleriesFound = FindObjectOfType<ArtworkLibrary>().GetGallery(galleryInput.text);
        foreach (string gallery in galleriesFound)
        {
            GameObject instance = Instantiate(gallerySearchOption, gallerySearchOptionsGrid);
            GallerySearchOptionUI optionUI = instance.GetComponent<GallerySearchOptionUI>();
            optionUI.title.text = gallery;

            //Setup the button listener
            optionUI.select.onClick.AddListener(delegate
            {
                //Load image targets
                GalleryArtworks galleryArtworks = FindObjectOfType<ArtworkLibrary>().GetGalleryArtworks(gallery);
                FindObjectOfType<ImageTargetManager>().UpdateImageTargets(galleryArtworks);

                //Close the search panel
                gallerySearchOptionsPanel.SetActive(false);

                //Set the current gallery text
                currentGallery.text = gallery;
            });
        }
    }
}
