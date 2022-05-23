using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class FileManagerUpdate : MonoBehaviour
{
    public string pathforJson;
    public string pathforLoad;

    public void OpenFileBrowserForJson()
    {
        pathforJson=EditorUtility.OpenFolderPanel("Select a folder for saves","","");

    }

    public void OpenFileBrowserForParameters()
    {
        pathforLoad=EditorUtility.OpenFilePanel("Select a file to load parameters for the bodypart","","csv");
    }
}
