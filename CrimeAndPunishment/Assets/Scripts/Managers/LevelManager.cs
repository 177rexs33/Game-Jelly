using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance { get; private set; }
    public List<Case> cases = new List<Case>();
    public List<Laws> laws = new List<Laws>();
    public int levelNumber = 1; // public for debugging (wackchamp)
    public TextMeshProUGUI fileText;
    public TextMeshProUGUI fileCrimes;
    public TextMeshProUGUI fileCrimeDates;
    public TextMeshProUGUI fileDescription;
    public TextMeshProUGUI lawName;
    public TextMeshProUGUI punishment;
    public static int caseColumns = 7; /// check that this matches the csv file
    public static int lawColumns = 2; /// check that deez lawColumns matches the csv file
    public StampAnimator stampAnimator;
    public FileAnimator fileAnimator;


    // Start is called before the first frame update
    void Awake()
    {
        //Makes and manages the instance for LevelManager
        if (instance != null)
        {
            Debug.Log("Level Manager: found more than one LM in the scene, the newest LM will be destroyed");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject); 
    }

    private void Start()
    {
        LoadLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeLevel()
    {
        levelNumber++;
        LoadLevel();
    }
    
    public void LoadLevel()
    {
        
        //uses the current level as an index in the cases list
        Case currentCase = cases[levelNumber - 1];
        fileText.text = $"Name: {currentCase.name}\nAge:  {currentCase.age}\nOccupation: {currentCase.occupation}\nCase Code: {currentCase.caseCode}\n";
        fileCrimes.text = "Crime\n" + currentCase.crime.Replace (";","\n");
        fileCrimeDates.text = "Date\n" + currentCase.crimeDate.Replace(";", "\n");
        fileDescription.text = "Notes:\n" + currentCase.notes;

        //reset buttons to charge buttons
        ButtonManager.instance.SetFileAssessment(true);

        //reset stamp to blank
        StampAnimator animator = stampAnimator.GetComponent<StampAnimator>();
        animator.BlankStamp();

        //Loads in file
        FileAnimator FA = fileAnimator.GetComponent<FileAnimator>();
        FA.FileEnter();

        //Loads in Laws
        Laws currentLaw = laws[levelNumber - 1];
        lawName.text = $"{currentLaw.lawName}";
        punishment.text = $"{currentLaw.punishment}";

        /*//debugging
        foreach (Case c in cases) 
        {
            c.PrintCase();
        }*/
    }

    public void LevelEnd()
    {
        //end of level aniamtions or anuything, such as file leaving scvren etc...
        //Removes Completed File from screen
        FileAnimator FA = fileAnimator.GetComponent<FileAnimator>();
        FA.FileExit();
    }


    public void StoreCaseData(string[] data)
    {
        // Debug.Log(data.Length);
        for (int i = caseColumns; (i + caseColumns) <= data.Length; i += caseColumns)
        {
            
            // Debug.Log(data[i] + data[i + 1] + data[i + 2] + data[i + 3] + data[i + 4] + data[i + 5] + data[i + 6]);
            cases.Add(new Case(data[i], data[i+1], data[i+2], data[i+3], data[i + 4], data[i + 5], data[i + 6]));
        }
    }

    public void StoreLawData(string[] data)
    {
        // Debug.Log(data.Length);
        for(int i = lawColumns; (i + lawColumns) <= data.Length; i += lawColumns)
        {
            // doesnt work LMAO
            Debug.Log(data[i] + data[i + 1]);
        }
    }
}
