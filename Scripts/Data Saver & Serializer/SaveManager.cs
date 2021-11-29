using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Save data and artworks, contains save functions to do various saving behaviours.
/// The loading process is for prototype and is not quite efficient.
/// </summary>
public class SaveManager : MonoBehaviour 
{
    public SaveState state;

    /// <summary>
    /// Load the data when awake.
    /// </summary>
    private void Awake() => Load();

    /// <summary>
    /// Delete the previous save data.
    /// </summary>
    public void Delete() => PlayerPrefs.DeleteKey("SaveData");

    /// <summary>
    /// Save everything in SaveState.
    /// </summary>
    public void Save() => PlayerPrefs.SetString("SaveData", Serializer.Serialize(state));

    /// <summary>
    /// Load the previous saved state from the player prefs.
    /// </summary>
    public void Load()
    {
        if (PlayerPrefs.HasKey("SaveData"))
            state = Serializer.Deserialize<SaveState>(PlayerPrefs.GetString("SaveData"));
        else
            state = new SaveState();
            Save();
            Debug.Log("No save file found, creating a new one.");
    }

    /// <summary>
    /// Add the artwork to the save file.
    /// </summary>
    /// <param name="artworkID">Artwork to add</param>
    public bool AddArtwork(string artworkID)
    {
        if (!state.artworksOwned.Contains(artworkID))
        {
            state.artworksOwned.Add(artworkID);
            Save();
            return true;
        }

        return false;
    }

    /// <summary>
    /// Remove the artwork from the save file.
    /// </summary>
    /// <param name="artworkID">Artwork to delete</param>
    public void RemoveArtwork(string artworkID)
    {
        if (state.artworksOwned.Contains(artworkID))
        {
            state.artworksOwned.Remove(artworkID);
            Save();
        }
        else
        {
            Debug.LogWarning("Remove artwork: Artwork ID not found.");
        }
    }

    /// <summary>
    /// Return the saved artworks ID in the save file loaded.
    /// </summary>
    /// <returns>The saved artworks ID</returns>
    public List<string> GetArtworksOwned() => state.artworksOwned;

}
