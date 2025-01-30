using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawbookInformationLoader : MonoBehaviour
{

    public TextAsset lawData; 

    // Start is called before the first frame update
    void Start()
    {
        ReadCSV();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReadCSV()
    {
        string[] data = lawData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        LevelManager.instance.StoreLawData(data);
        Debug.Log("FileInformationLoader: Law Data stored.");
    }
}
