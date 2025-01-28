using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignatureAnimator : MonoBehaviour
{
    private Animator _anim;
    private SpriteRenderer _renderer;

    private int state;

    public FileAnimator file;

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

    public void Blank()
    {
        state = blank;
    }

    public void Signing()
    {
        state = signing;
    }

    public void Signed()
    {
        state = signed;
    }

    public void LevelEndAfterSignature()
    {
        //call levelmanager
        LevelManager.instance.LevelEnd();
    }


    #region Cached Properties

    private int _currentState;

    private static readonly int blank = Animator.StringToHash("Blank");
    private static readonly int signing = Animator.StringToHash("Signing");
    private static readonly int signed = Animator.StringToHash("Signed");

    #endregion
}
