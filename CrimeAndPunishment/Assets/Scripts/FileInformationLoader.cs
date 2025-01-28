using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//source: https://youtu.be/tI9NEm02EuE?si=UG5-H1NDi0mMAgZG

public class FileInformationLoader : MonoBehaviour
{
    public TextAsset caseData;

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
        string[] data = caseData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        LevelManager.instance.StoreCaseData(data);
        Debug.Log("FileInformationLoader: Data stored.");
    }
}
