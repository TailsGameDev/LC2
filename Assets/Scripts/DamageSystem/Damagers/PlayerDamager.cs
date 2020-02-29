using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: make collider activation really synchronized with the animation

public class PlayerDamager : DamagerTemplate
{
    [SerializeField]
    private int enableDelayInFrames, disableDelayInFrames;

    [SerializeField]
    private Collider2D col2D;

    public void ActivateColliderDuringAttackAnimation()
    {
        StartCoroutine(DamagerHistory());
    }

    IEnumerator DamagerHistory()
    {
        yield return StartCoroutine(
            SetColliderEnabledAfterDelay(enable: true, enableDelayInFrames)
        );

        yield return StartCoroutine(
            SetColliderEnabledAfterDelay(enable: false, disableDelayInFrames)
        );
    }

    IEnumerator SetColliderEnabledAfterDelay(bool enable, int delayInFrames)
    {
        yield return StartCoroutine(
            WaitForFrames(frames: delayInFrames)
        );

        SetColliderEnabled(enable);
    }

    IEnumerator WaitForFrames(int frames)
    {
        int counter = frames;
        while ( counter > 0)
        {
            counter--;
            yield return null;
        }
    }

    void SetColliderEnabled(bool enable)
    {
        GetComponent<SpriteRenderer>().enabled = enable;
        col2D.enabled = enable;
    }

    protected override void AfterDoingDamage()
    {
        SetColliderEnabled(false);
    }
}
