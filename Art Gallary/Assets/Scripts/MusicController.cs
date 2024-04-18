using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource musicSource;
    public GameObject soundOrigin; // GameObject representing the position of the sound

    private string volumeKey = "MusicVolume"; // Key to use for saving and loading the volume

    // Start is called before the first frame update
    void Start()
    {
        // Load the volume value from PlayerPrefs, or set it to default (0.5) if not present
        float savedVolume = PlayerPrefs.GetFloat(volumeKey, 0.5f);
        volumeSlider.value = savedVolume;
        musicSource.volume = savedVolume;

        // Add a listener to the slider's value changed event
        volumeSlider.onValueChanged.AddListener(ChangeVolume);

        // Set the initial position of the sound to the soundOrigin GameObject
        musicSource.transform.position = soundOrigin.transform.position;
    }

    // Function to be called when the slider value changes
    void ChangeVolume(float volume)
    {
        // Change the music volume based on the slider value
        musicSource.volume = volume;
        // Save the volume value to PlayerPrefs
        PlayerPrefs.SetFloat(volumeKey, volume);
    }
}
