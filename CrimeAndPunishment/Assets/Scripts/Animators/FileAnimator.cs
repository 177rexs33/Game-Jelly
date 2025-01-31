using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileAnimator : MonoBehaviour
{
    private Animator _anim;
    private SpriteRenderer _renderer;

    public int state;

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

    public void FileEnter()
    {
        state = fileEnter;
    }

    public void FileStatic()
    {
        state = fileStatic;
    }

    public void FileExit()
    {
        state = fileExit;
    }

    public void FileGone()
    {
        state = gone;
    }

    #region Cached Properties

    private int _currentState;

    private static readonly int fileEnter = Animator.StringToHash("File_Enter");
    private static readonly int fileStatic = Animator.StringToHash("File_Static");
    private static readonly int fileExit = Animator.StringToHash("File_Exit");
    private static readonly int gone = Animator.StringToHash("File_Gone");


    #endregion
}
