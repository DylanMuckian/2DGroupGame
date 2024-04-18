using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{

    [Header("Volume Settings")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider  volumeSlider = null;
    [SerializeField] private GameObject confirmationPromt = null;
    [SerializeField] private float defaultVolume = 1.0f;
    
    private float volume;

    [Header("Levels To Load")]
    public string Gameplay;
    private string levelToLoad;
    [SerializeField] private GameObject noSavedGameDialog = null;
    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(Gameplay);
    }

    public void LoadGameDialogYes()
    {
        if(PlayerPrefs.HasKey("SavedLevel"))
        {
            levelToLoad = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(levelToLoad);
        }
        else
        {
            noSavedGameDialog.SetActive(true);
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void SetVolume()
    {
        // AudioListener.volume = volume;
        // volumeTextValue.text = volume.ToString("F1");
        
        volume = volumeSlider.value;
        volumeTextValue.text = volume.ToString("F1");
        
    }
    // public void SetVolume(float volume)
    // {
    //     AudioListener.volume = volume;
    //     volumeTextValue.text = volume.ToString("F1");
    // }

    public void VolumeApply()
    {
       PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(confirmationBox());
    }

    public IEnumerator confirmationBox() 
    { 
        confirmationPromt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPromt.SetActive(false);
    }
}

//35:00 into video (need to fix volume)