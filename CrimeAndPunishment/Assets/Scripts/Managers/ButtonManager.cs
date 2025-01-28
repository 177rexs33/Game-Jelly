using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance { get; private set; }
    public Button guiltyButton;
    public Button releaseButton;
    public Button signButton;
    private bool fileAssessment = true;
    public StampAnimator stampAnimator;

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
        //do guilty stamp aniamtion
        StampAnimator animator = stampAnimator.GetComponent<StampAnimator>();
        animator.GuiltyStamp();

        SetFileAssessment(false);
    }

    public void releaseButtonPressed()
    {
        //do release stamp animation
        StampAnimator animator = stampAnimator.GetComponent<StampAnimator>();
        animator.ReleaseStamp();

        SetFileAssessment(false);
    }

    public void signButtonPressed()
    {
        //do signature animation
        // wait a bit, then change to next level
        // LevelManager.instance.ChangeLevel();
    }

    /* later, pause menu when presse esc
    public void escPressed(){}
    */
}
