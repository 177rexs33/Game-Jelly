using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case
{
    public string name;
    public string age;
    public string occupation;
    public string crime;
    public string crimeDate;
    public string caseCode;
    public string notes;

    public Case(string name, string age, string occupation, string caseCode, string crime, string crimeDate, string notes)
    {
        this.name = name;
        this.age = age;
        this.occupation = occupation;
        this.crime = crime;
        this.crimeDate = crimeDate;
        this.caseCode = caseCode;
        this.notes = notes;
    }

    public void PrintCase()
    {
        string listedCase = $"Name: {this.name}\nAge:  {this.age}\nOccupation: {this.occupation}\nCase Code: {this.caseCode}\nCrime: {this.crime}\nCrime Date: {this.crimeDate}\nNotes; {this.notes}";
        Debug.Log(listedCase);
    }
}
