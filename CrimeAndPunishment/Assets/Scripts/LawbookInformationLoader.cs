using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Actually the rule sheet loader
public class LawbookInformationLoader : MonoBehaviour
{

    public TextAsset ruleData; 

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
        string[] data = ruleData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        LevelManager.instance.StoreRuleData(data);
        //Debug.Log("FileInformationLoader: rule sheet Data stored.");
        LevelManager.instance.LoadLevel();
    }
}
