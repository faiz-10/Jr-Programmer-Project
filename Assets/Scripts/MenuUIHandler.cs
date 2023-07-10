using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;
    public static Color colorSelected;

    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
        // transfer this color to next scene;
        MainManager.Instance.TeamColor = color;
        Debug.Log("color selected " + color);
        
    }
    
    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;
        ColorPicker.SelectColor(MainManager.Instance.TeamColor);
    }
    public void SwithScene()
    {
        SceneManager.LoadScene(sceneName: "Main");
    }
    
    public void Exit()
    {
        MainManager.Instance.SaveColor();
        //conditional compiling
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
#if !UNITY_EDITOR
        Application.Quit();
#endif
        
        //Application.Quit();(works for built applications only)
    }

    public void SaveColorClicked()
    {
        MainManager.Instance.SaveColor();
    }

    public void LoadColorClicked()
    {
        MainManager.Instance.LoadColor();
        ColorPicker.SelectColor(MainManager.Instance.TeamColor);
    }


}
