using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance { get; private set; }
    public Button guiltyButton;
    public Button releaseButton;
    public Button signButton;
    public bool lastButtonPress;
    private bool fileAssessment = true;
    public LevelManager levelmanager;
    private int overallScoreCounter = 0;
    private int levelCounter = 1;
    private List<bool> correctAnswer = new List<bool>() { true, true, true, false,
                                                          false, true, false, false, false,
                                                          true, false, true, true, true};
    public ActualStampAnimator stampAnimator;
    public TextMeshProUGUI laws;
    private int page = 1;
    private string firstPage = "Artificial Intelligence Creation:\r\n\tDeath Penalty\r\nArson:\r\n\tFrom 5 to 20 years in prison and 2 \r\n\tmillion in fines\r\nAssault:\r\n\tUp to 2 years in prison and up to 80 \r\n\thours of community service\r\nBlackmail:\r\n\tUp to 1 year in prison\r\nBurglary:\r\n\tUp to 5 years in prison and up to 50 \r\n\tthousand in fines\r\nCounterfeiting:\r\n\tUp to 5 years in prison and 10 million in \r\n\tfines\r\nCloning of an Artficial Intelligence:\r\n\tUp to 2 years in prison and 10 thousand \r\n\tin fines\r\nDisorderly Conduct:\r\n\tUp to 90 days in prison and 5 thousand \r\n\tin fines\r\n";
    private string secondPage = "Disturbing the Peace:\r\n\tUp to 90 days in prison\r\nDrug Possession:\r\n\t1 year per offense\r\nDrug Trafficking:\r\n\t4 years in prison\r\nFraud:\r\n\t3 years in prison and 90 hours of \r\n\tcommunity service\r\nIdentity Theft:\r\n\t50 years in prison and up to 50 million \r\n\tin fines\r\nKidnapping:\r\n\tThe Death Penalty\r\nManslaughter: Involuntary:\r\n\t2 thousand hours of community \r\n\tservice\r\nManslaughter: Voluntary:\r\n\t40 years in prison\r\nMovement of a Celestial Body:\r\n\tThe Death Penalty\r\nMurder: Premeditated:\r\n\tThe Death Penalty";
    private string thirdPage = "Murder: Not Premeditated:\t\r\n\t120 years in prison\r\nMurder of an Artificial Intelligence:\r\n\tThe Death Penalty\r\nPlacing Pineapple on Pizza:\r\n\t1 hour of community service per \r\n\toffense\r\nStalking:\r\n\tUp to 5 years in prison and 10 thousand \r\n\tin fines\r\nVandalism:\r\n\t180 days in jail";

    // Start is called before the first frame update
    void Awake()
    {
        //Makes and manages the instance for ButtonManager
        if (instance != null)
        {
            Debug.Log("Button Manager: found more than one BM in the scene, the newest BM will be destroyed");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetFileAssessment(bool value)
    {
        fileAssessment = value;
        if (fileAssessment)
        {
            guiltyButton.gameObject.SetActive(true);
            releaseButton.gameObject.SetActive(true);

            signButton.gameObject.SetActive(false);
        }
        else
        {
            signButton.gameObject.SetActive(true);

            guiltyButton.gameObject.SetActive(false);
            releaseButton.gameObject.SetActive(false);
        }
    }

    public bool GetFileAssessment()
    { 
        return fileAssessment;
    }

    public void guiltyButtonPressed()
    {

        lastButtonPress = true;
        //Debug.Log(lastButtonPress);
        //do guilty stamp aniamtion
        ActualStampAnimator animator = stampAnimator.GetComponent<ActualStampAnimator>();
        animator.StampingGuilty(); // changte htis to actuall stamp

        SetFileAssessment(false);
    }

    public void releaseButtonPressed()
    {
        //Debug.Log("button clicked");

        lastButtonPress = false;
        //Debug.Log(lastButtonPress);
        //do release stamp animation
        ActualStampAnimator animator = stampAnimator.GetComponent<ActualStampAnimator>();
        animator.StampingRelease(); // changte htis to actuall stamp

        SetFileAssessment(false);
    }

    public void signButtonPressed()
    {
        
        /*bool levelAnswer = correctAnswer[levelCounter - 1];
        //Debug.Log(levelAnswer);
        if (levelAnswer == lastButtonPress)
        {
            ++overallScoreCounter;
        }
        else
        {
            --overallScoreCounter;
        }*/
       // Debug.Log(overallScoreCounter);
        
        //Debug.Log(levelmanager.ReturnLevel());
        bool levelAnswer = correctAnswer[levelmanager.ReturnLevel() - 1];
        //Debug.Log(levelAnswer);
        if (levelAnswer == lastButtonPress)
        {
            ++overallScoreCounter;
        }
        else
        {
            --overallScoreCounter;
        }
        

    }

    public int ReturnScore()
    {
        return overallScoreCounter;
    }

    public void PageForward()
    {
        if (page < 3)
        {
            page++;
        }

        UpdatePage();
    }

    public void PageBackward()
    {
        if (page > 1)
        {
            page--;
        }

        UpdatePage();
    }
    public void UpdatePage()
    {
        if (page == 1)
        {
            laws.text = firstPage;

        }
        else if (page == 2) 
        {
            laws.text = secondPage;
        }
        else
        {
            laws.text = thirdPage;
        }
    }
    
}
