using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

/// <summary>
/// This script creates the parallax effect of the artwork.
/// </summary>
public class ImageParallaxEffect : MonoBehaviour
{
    public GameObject layerObject;
    public Transform layerParent;

    /// <summary>
    /// Setup parallax effect, spawn layers instance on the image target
    /// </summary>
    /// <param name="artwork">The artwork to setup layers</param>
    public void SetupParallaxLayers(Artwork artwork)
    {
        float layerHeight = -0.008f;
        float currentIndex = 1;

        //Clean all layers in the parent
        foreach (Transform child in layerParent) Destroy(child.gameObject);

        //Setup parallax layers
        foreach(Sprite layer in artwork.parallaxLayers)
        {
            GameObject instance = Instantiate(layerObject, layerParent);
            instance.GetComponent<Image>().sprite = layer;
            instance.transform.localScale = Vector3.one * artwork.parallaxLayerSize;
            instance.transform.Translate(new Vector3(0, 0, layerHeight * currentIndex), Space.Self);
            currentIndex++;
        }
    }

    /// <summary>
    /// Toggle parallax effect, set game objects active and inactive
    /// </summary>
    public void ToggleParallaxEffect() => layerParent.gameObject.SetActive(layerParent.gameObject.activeSelf ? false : true);
    
}
