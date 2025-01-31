using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualStampAnimator : MonoBehaviour
{
    private Animator _anim;
    private SpriteRenderer _renderer;

    private int state;

    public StampAnimator stampAnimator;

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

    public void NoStamp()
    {
        state = noStamp;
    }

    public void StampingRelease()
    {
        state = stampingRelease;
    }

    public void StampingGuilty()
    {
        state = stampingGuilty;
    }

    public void CallReleaseStamp()
    {
        StampAnimator sanim = stampAnimator.GetComponent<StampAnimator>();
        sanim.Release();
    }

    public void CallGuiltyStamp()
    {
        StampAnimator sanim = stampAnimator.GetComponent<StampAnimator>();
        sanim.Guilty();
    }




    #region Cached Properties

    private int _currentState;

    private static readonly int noStamp = Animator.StringToHash("No_Stamp");
    private static readonly int stampingRelease = Animator.StringToHash("Stamping");
    private static readonly int stampingGuilty = Animator.StringToHash("Guilty");

    #endregion
}
