using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;

    public Slider musicSlider;

    Resolution[] resolutions;

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("MusicVolume", 0));
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0);

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if( resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height )
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        
    }

    public void Back()
    {
        float music = 0;

        audioMixer.GetFloat("volume", out music);

        PlayerPrefs.SetFloat("MusicVolume", music);
        PlayerPrefs.Save();

        SceneManager.LoadScene("Menu");
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
