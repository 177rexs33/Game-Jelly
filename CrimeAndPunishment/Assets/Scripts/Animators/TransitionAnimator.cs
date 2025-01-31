using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class TransitionAnimator : MonoBehaviour
{
    private Animator _anim;
    private SpriteRenderer _renderer;

    private int state;

    public TextMeshProUGUI dayText;

    private static string[] numberStrings = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten"};

    public FileAnimator fileAnimator;
    public Canvas transCanvas;

    void Awake()
    {
        _anim = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (state == _currentState) return;
        _anim.CrossFade(state, 0, 0);
        _currentState = state;
    }

    public void FadeIn()
    {
        
        state = fadeIn;
        
    }

    public void FadeOut()
    {
        
        state = fadeOut;
    }
    
    public void SetDay(int day)
    {
        dayText.text = "Day " + numberStrings[day];
    }

    public void CallFileAnimator()
    {
        // reset buttons to charge buttons
        ButtonManager.instance.SetFileAssessment(true);
        transCanvas.gameObject.SetActive(false);
        FileAnimator FA = fileAnimator.GetComponent<FileAnimator>();
        FA.FileEnter();
        
    }

    public void HideFileAnimator()
    {
        FileAnimator FA = fileAnimator.GetComponent<FileAnimator>();
        FA.FileGone();
    }
    


    #region Cached Properties

    private int _currentState;

    private static readonly int fadeIn = Animator.StringToHash("Fade_In");
    private static readonly int fadeOut = Animator.StringToHash("Fade_Out");

    #endregion
}
