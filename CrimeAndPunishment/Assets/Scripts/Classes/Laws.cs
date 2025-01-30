using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laws 
{
    public string lawName;
    public string punishment;

    public Laws(string lawName, string punishment)
    {

        this.lawName = lawName;
        this.punishment = punishment;

    }

    public void printLaws()
    {
        string listedLaws = $"{this.lawName} formatingsmormating {this.punishment}";
        Debug.Log(listedLaws);
    }
}
