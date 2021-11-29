using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageTargetManager : MonoBehaviour
{
    public GameObject ARFunctions;

    public void UpdateImageTargets(GalleryArtworks galleryArtworks)
    {
        //Create a parent for targets if there is no parent object
        GameObject parent = GameObject.Find("ImageTargets") ? GameObject.Find("ImageTargets") : new GameObject("ImageTargets");

        //Clean the targets in parent
        foreach (Transform child in parent.transform) Destroy(child.gameObject);

        //Create image targets
        foreach(Artwork artwork in galleryArtworks.artworks)
        {
            //Create a image target at runtime
            var instance = Vuforia.VuforiaBehaviour.Instance.ObserverFactory.CreateImageTarget(artwork.ARImageTarget, 0.1f, "Target");
            //Add the Default Observer Event Handler to the newly created game object
            instance.gameObject.AddComponent<DefaultObserverEventHandler>();
            //Set parent of the image target
            instance.gameObject.transform.SetParent(parent.transform);

            //Create the AR UI game object
            GameObject ARInstance = Instantiate(ARFunctions, instance.gameObject.transform);
            //Setup the AR functions
            ARInstance.GetComponent<ARFunctionsManager>().Setup(artwork);
        }
    }
}
