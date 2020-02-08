using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void AnimateWalk(bool w, bool s, bool a, bool d)
    {
        if (PlayerInput.IsJustOneMovementKeyPressed())
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
    }
}
