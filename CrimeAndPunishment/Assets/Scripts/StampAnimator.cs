using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampAnimator : MonoBehaviour
{
    private Animator _anim;
    private SpriteRenderer _renderer;

    private int state;

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

    public void BlankStamp()
    {
        state = blankStamp;
    }

    public void GuiltyStamp()
    {
        state = stampGuilty;
    }
    
    public void Guilty()
    {
        state = guilty;
    }

    public void ReleaseStamp()
    {
        state = stampRelease;
    }

    public void Release()
    {
        state = release;
    }


    #region Cached Properties

    private int _currentState;

    private static readonly int blankStamp = Animator.StringToHash("Stamp_Blank");
    private static readonly int stampGuilty = Animator.StringToHash("Stamp_Guilty");
    private static readonly int guilty = Animator.StringToHash("Guilty");
    private static readonly int stampRelease = Animator.StringToHash("Stamp_Release");
    private static readonly int release = Animator.StringToHash("Release");

    #endregion
}
