using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance { get; private set; }
    public List<Case> cases = new List<Case>();
    public List<Laws> rules = new List<Laws>();
    private static int totalLevels = 15;
    public ButtonManager buttonManager;
    public int levelNumber = 1; // public for debugging (wackchamp)
    //private static int totalDays = 3;
    private static int casesPerDay = 5;
    private int dayIndex = 0;
    public int dayNumber = 1;
    public TextMeshProUGUI fileText;
    public TextMeshProUGUI fileCrimes;
    public TextMeshProUGUI fileCrimeDates;
    public TextMeshProUGUI fileDescription;
    public TextMeshProUGUI ruleSheet;
    public TextMeshProUGUI lawName;
    public TextMeshProUGUI score;
    public static int caseColumns = 7; /// check that this matches the csv file
    public static int lawColumns = 1; /// check that deez RULEColumns matches the csv file
    public StampAnimator stampAnimator;
    public FileAnimator fileAnimator;
    public TransitionAnimator transAnimator;
    public SignatureAnimator signatureAnimator;
    public Canvas transCanvas;


    // Start is called before the first frame update
    void Awake()
    {
        // Makes and manages the instance for LevelManager
        if (instance != null)
        {
            //Debug.Log("Level Manager: found more than one LM in the scene, the newest LM will be destroyed");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject); 
    }

    private void Start()
    {
        // reset buttons to charge buttons
        ButtonManager.instance.SetFileAssessment(true);
        //do day animation

        transCanvas.gameObject.SetActive(true);
        TransitionAnimator transitionAnimator = transAnimator.GetComponent<TransitionAnimator>();
        transitionAnimator.SetDay(dayNumber);
        transitionAnimator.FadeIn();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeLevel()
    {
        
        levelNumber++;

        if (levelNumber % 5 == 0)
        {
            dayNumber++;
        }

        //Debug.Log("LM: changing level to " + levelNumber);

        // Loads in new rule set if new day
        if (levelNumber % casesPerDay == 0)
        {
            // reset buttons to charge buttons
            ButtonManager.instance.SetFileAssessment(true);
            // new day, trasition animation
            transCanvas.gameObject.SetActive(true);
            TransitionAnimator transitionAnimator = transAnimator.GetComponent<TransitionAnimator>();
            //Debug.Log("Day: " + dayNumber);
            transitionAnimator.SetDay(dayNumber);
            transitionAnimator.FadeOut();

            UpdateRuleSheet();


        }

        LoadLevel();
        //Debug.Log(buttonManager.ReturnScore());
        score.text = $"Score: {buttonManager.ReturnScore().ToString()}";
        //Debug.Log(score.text);
    }

    public void UpdateRuleSheet()
    {
        ruleSheet.text += rules[dayIndex].lawName + "\n\n" + rules[dayIndex + 1].lawName + "\n\n";
        dayIndex += 2;
    }
    
    public void LoadLevel()
    {
        
        
        // uses the current level as an index in the cases list
        Case currentCase = cases[levelNumber - 1];
        fileText.text = $"Name: {currentCase.name}\nAge:  {currentCase.age}\nOccupation: {currentCase.occupation}\nCase Code: {currentCase.caseCode}\n";
        fileCrimes.text = "Crime\n" + currentCase.crime.Replace(";","\n");
        fileCrimeDates.text = "Date\n" + currentCase.crimeDate.Replace(";", "\n");
        fileDescription.text = "Notes:\n" + currentCase.notes;
       
        

        

        // reset stamp to blank
        StampAnimator animator = stampAnimator.GetComponent<StampAnimator>();
        animator.BlankStamp();

        // reset signature to blank
        SignatureAnimator signAnimator = signatureAnimator.GetComponent<SignatureAnimator>();
        signAnimator.Blank();


        
        if (levelNumber == 1)
        {
            UpdateRuleSheet();
        }


        //Loads in file when it is the same day
        if ((levelNumber % casesPerDay != 0) && levelNumber > 1)
        {
            // reset buttons to charge buttons
            //Debug.Log("LM: callign fiule to enter");

            
            ButtonManager.instance.SetFileAssessment(true);
            FileAnimator FA = fileAnimator.GetComponent<FileAnimator>();
            //Debug.Log(FA.state);
            FA.FileEnter();
            //Debug.Log(FA.state);


        }

        

        /*//debugging
        foreach (Case c in cases) 
        {
            c.PrintCase();
        }

        foreach (Laws l in rules) 
        {
            l.printLaws();
        }  
        */
    }

    public void LevelEnd()
    {
        // end of level aniamtions or anuything, such as file leaving scvren etc...
        // Removes Completed File from screen
        FileAnimator FA = fileAnimator.GetComponent<FileAnimator>();
        FA.FileExit();

        if (levelNumber < totalLevels)
        {
            ChangeLevel();
        }
        else
        {
            //Debug.Log("end of game");
            //end of game, doing fade for now

            // vv this is not working for some reason...
            transCanvas.gameObject.SetActive(true);
            TransitionAnimator transitionAnimator = transAnimator.GetComponent<TransitionAnimator>();
            transitionAnimator.FadeOut();
        }

    }

    public int ReturnLevel()
    {
        return levelNumber;
    }

    public void StoreCaseData(string[] data)
    {
        //Debug.Log(data.Length);
        for (int i = caseColumns; (i + caseColumns) <= data.Length; i += caseColumns)
        {
            
            // Debug.Log(data[i] + data[i + 1] + data[i + 2] + data[i + 3] + data[i + 4] + data[i + 5] + data[i + 6]);
            cases.Add(new Case(data[i], data[i+1], data[i+2], data[i+3], data[i + 4], data[i + 5], data[i + 6]));
        }
    }

    public void StoreRuleData(string[] data)
    {
        //Debug.Log(data.Length);
        foreach (string rule in data)
        {
            rules.Add(new Laws(rule.Replace(';', ',')));
        }

        foreach (Laws l in rules)
        {
            l.printLaws();
        }

        //Debug.Log(rules.Count);
        
    }
}
