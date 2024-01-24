using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using UnityEngine.Events;
using System;

public class Quality_dropdown : MonoBehaviour
{
    [SerializeField] public UnityEvent onOptionsMenuClosed;
    [SerializeField] TMP_Dropdown qualityDropdown;
    [SerializeField] TMP_Dropdown resolutionDropdown; 
    Canvas canvas;



    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        { 
            List <TMP_Dropdown.OptionData> options= new List <TMP_Dropdown.OptionData> ();  
            for (int i=0; i<QualitySettings.count; i++)
            {
                TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData ();
                option.text = QualitySettings.names[i]; 
                options.Add (option);//añadimos a estas opciones la opcion para poder crear
            }
            qualityDropdown.options = options;
            qualityDropdown.onValueChanged.AddListener(OnQualityDropDownValueChanged);
        }
        //1- cambiar la resolucion a través de un TMP_DropDown
        //List<TMP_Dropdown.OptionData> options1 = new List<TMP_Dropdown.OptionData>();
        //Resolution[] resolutions;
        //
        //for (int i = 0; i < Screen.resolutions.Length; i++)
        //{
        //    TMP_Dropdown.OptionData option1 = new TMP_Dropdown.OptionData();
        //    options1.text= resolutions[i].ToString();
        //    resolutionDropdown.options.Add (option1);
        //}
        //resolutionDropdown.options = options; 

        {
            int currentResolution = -1; 
            List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
            for (int i = 0; i < Screen.resolutions.Length; i++)
            {
                TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
                //option.text =Screen.resolutions[i].ToString();
                option.text=""+Screen.resolutions[i].width+"x"+Screen.resolutions[i].height+"-"+Mathf.RoundToInt((float)Screen.resolutions[i].refreshRateRatio.value)+"Hz"; 
                //options.text= $"{Screen.resolutions[i].width}x{Screen.resolutions[i].height}-"+"; 
                options.Add(option);//añadimos a estas opciones la opcion para poder crear 

                if (Screen.currentResolution.width == Screen.resolutions[i].width&&
                (Screen.currentResolution.height == Screen.resolutions[i].height)&&
                (Screen.currentResolution.refreshRateRatio.value == Screen.resolutions[i].refreshRateRatio.value)
                )
                {
                    currentResolution = i; 
                }
            }
            resolutionDropdown.options = options;
            resolutionDropdown.value = currentResolution; 
            resolutionDropdown.onValueChanged.AddListener(OnResolutionDropDownValueChanged);
        }
        // Screen.resolutions;
        // Screen.SetResolution();
        ////////////////////////////////////////////////////////////

        //2- Cambiar el valor de la resolución y de la caldiad, y recuperarlo en la siguiente partida
        //QualitySettings.level;
        canvas.enabled = false; 

    }

    private void OnQualityDropDownValueChanged(int value)
    {
        QualitySettings.SetQualityLevel(value); 
    }
    private void OnResolutionDropDownValueChanged(int value)
    {
        Screen.SetResolution(
        Screen.resolutions[value].width, 
        Screen.resolutions[value].height,
        FullScreenMode.Windowed, 
        Screen.resolutions[value].refreshRateRatio);
    }

    public void onBack()
    {
        canvas.enabled = false;
        onOptionsMenuClosed.Invoke ();  
    }
}
