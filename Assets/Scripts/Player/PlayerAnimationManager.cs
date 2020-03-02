using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    [SerializeField] Animator animator;
    bool justOneMovementKeyIsPressed = false;

    public void InformIfJustOneMovementKeyIsPressed(bool justOneMovementKeyIsPressed)
    {
        this.justOneMovementKeyIsPressed = justOneMovementKeyIsPressed;
    }

    public void AnimateWalk(bool w, bool s, bool a, bool d)
    {
        if (justOneMovementKeyIsPressed)
        {
            SetWalkParameters(w, s, a, d);
        } else
        {
            SetWalkParameters(false, false, false, false);
        }
    }

    void SetWalkParameters(bool w, bool s, bool a, bool d)
    {
        animator.SetBool("isWalkingUp", w);
        animator.SetBool("isWalkingDown", s);
        animator.SetBool("isWalkingLeft", a);
        animator.SetBool("isWalkingRight", d);

        animator.SetBool("isWalking", w || s || a || d);
    }

    public void AnimateAttack(bool pressedAttackKey)
    {
        if (pressedAttackKey)
        {
            animator.SetTrigger("pressedAttackKey");
        }
    }

    public void InformDamaged()
    {
        animator.SetTrigger("damaged");
    }
}
