using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// This script enables user to view information, save and share artwork in AR world space.
/// </summary>
[RequireComponent(typeof(ImageParallaxEffect))]
public class ARFunctionsManager : MonoBehaviour
{
    public Button saveArtwork;
    public Button showDetails;
    public Button toggleParallax;
    public GameObject artworkPanel;

    // Start is called before the first frame update
    public void Setup(Artwork artwork)
    {
        //Setup parallax effect
        GetComponent<ImageParallaxEffect>().SetupParallaxLayers(artwork);
        toggleParallax.onClick.AddListener(delegate
        {
            GetComponent<ImageParallaxEffect>().ToggleParallaxEffect();
        });

        //Setup button listeners
        saveArtwork.onClick.AddListener(delegate 
        {
            bool success = FindObjectOfType<UserArtworkLibraryManager>().AddArtwork(artwork.id);
            if (success) FindObjectOfType<NotificationBox>().Show("Artwork Saved to Your Collection.");
            if (!success) FindObjectOfType<NotificationBox>().Show("Artwork Already Saved.");
        });
        showDetails.onClick.AddListener(delegate
        {
            //Show the panel
            artworkPanel.SetActive(artworkPanel.activeSelf? false : true);
        });

        //Setup the UI values
        ArtworkWorldSpacePanelUI panelUI = artworkPanel.GetComponent<ArtworkWorldSpacePanelUI>();
        panelUI.title.text = artwork.title;
        panelUI.subtitle.text = artwork.subtitle;
        panelUI.author.text = artwork.author;
        panelUI.brief.text = artwork.brief;
        panelUI.description.text = artwork.description;
    }
}
