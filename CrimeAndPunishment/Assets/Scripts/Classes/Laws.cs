using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laws
{
    public string lawName;
    public string punishment;

    public Laws(string lawName)
    {

        this.lawName = lawName;

    }

    public void printLaws()
    {
        string listedLaws = $"{this.lawName} formatingsmormating";
        Debug.Log(listedLaws);
    }
}
