using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System;
using TMPro;


public class TitleManager : MonoBehaviour
{
    //unity Tutorials..https://gamedevbeginner.com/
    //Tutorial Configuracion ..https://www.red-gate.com/simple-talk/development/dotnet-development/how-to-create-a-settings-menu-in-unity/
    // Start is called before the first frame update


    [SerializeField] public AudioMixer audioMixer;
    [SerializeField] public TMP_Dropdown resolutionDropdown;
    [SerializeField] public TMP_Dropdown qualityDropdown;
    [SerializeField] public TMP_Dropdown textureDropdown;
    [SerializeField] public TMP_Dropdown aaDropdown; 
    [SerializeField] public Slider volumeSlider;
    float currentVolume;
    Resolution[]  resolutions;
    //-----------------------------
    [SerializeField] GameObject PanelOpciones;
    [SerializeField] GameObject PanelMenu;

    

    void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height==Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        LoadSetting(currentResolutionIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        currentVolume=volume;
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions [ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }


    public void SetTextureQuality(int textureIndex)
    {
        QualitySettings.globalTextureMipmapLimit=textureIndex;
        qualityDropdown.value = 6;
    }

    public void SetAntiAlising(int aaIndex)
    {
        QualitySettings.antiAliasing = aaIndex;
        qualityDropdown.value = 6;
    }

    public void SetQuality(int qualityIndex)
    {
        if (qualityIndex != 6)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }
        switch (qualityIndex)
        {
            case 0: //Calidad Muy bajo
                textureDropdown.value=3;
                aaDropdown.value = 0;
                break;

            case 1: //Calidad Bajo
                textureDropdown.value = 2;
                aaDropdown.value = 0;
                break;

            case 2://Calidad Medio
                textureDropdown.value = 1;
                aaDropdown.value = 0;
                break;

            case 3://Calidad Alto
                textureDropdown.value = 0;
                aaDropdown.value = 0;
                break;

            case 4://Calidad Alto
                textureDropdown.value = 0;
                aaDropdown.value = 1;
                break;

            case 5: //Calidad Muy alto
                textureDropdown.value = 0;
                aaDropdown.value = 2;
                break;





        }
        qualityDropdown.value = qualityIndex;
    }


    public void SaveSetting()
    {
        PlayerPrefs.SetInt("QualitySettingPreference",qualityDropdown.value);
        PlayerPrefs.SetInt("ResolutionSettingPreference",resolutionDropdown.value);
        PlayerPrefs.SetInt("TextureSettingPreference",textureDropdown.value);
        PlayerPrefs.SetInt("AntiAlisingPreference",aaDropdown.value);
        PlayerPrefs.SetInt("TextureQualityPreference",textureDropdown.value);
        PlayerPrefs.SetInt("FullScreenPreference",Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetFloat("VolumePreference",currentVolume);
    }

    public void LoadSetting(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("QualitySettingPreference"))
        {
            qualityDropdown.value = PlayerPrefs.GetInt("QualitySettingPreference");
        }
        else
        {
            qualityDropdown.value = 3;
        }
        if (PlayerPrefs.HasKey("ResolutionSettingPreference"))
        {
            resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionSettingPreference");
        }
        else
        {
            resolutionDropdown.value = currentResolutionIndex;
        }
        if (PlayerPrefs.HasKey("TextureSettingPreference"))
        {
            qualityDropdown.value = PlayerPrefs.GetInt("TextureSettingPreference");
        }
        else
        {
            textureDropdown.value = 0;
        }
        if (PlayerPrefs.HasKey("AntiAlisingPreference"))
        {
            qualityDropdown.value = PlayerPrefs.GetInt("AntiAlisingPreference");
        }
        else
        {
            aaDropdown.value = 1;
        }
        if (PlayerPrefs.HasKey("FullScreenPreference"))
        {
            qualityDropdown.value = PlayerPrefs.GetInt("FullScreenPreference");
        }
        else
        {
            Screen.fullScreen = Convert.ToBoolean(PlayerPrefs.GetInt("FullScreenPreference"));
        }
        if (PlayerPrefs.HasKey("VolumePreference"))
        {
            volumeSlider.value = PlayerPrefs.GetFloat("VolumePreference");
        }
        else
        {
            volumeSlider.value = PlayerPrefs.GetFloat("VolumePreference");
        }
        

    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Opciones()
    {
        PanelOpciones.SetActive(true);
        PanelMenu.SetActive(false);
    }
    
    public void Salir()
    {
        Application.Quit();
    }
    public void SalirOpciones()
    {
        PanelOpciones.SetActive(false);
        PanelMenu.SetActive(true);
    }
}
