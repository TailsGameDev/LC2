using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void attack()
    {
        animator.SetTrigger("attack");
    }
}
