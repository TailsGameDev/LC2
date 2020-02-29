using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] PlayerDamager playerDamager;
    [SerializeField] Transform centerOfRotation;

    void RotateAttackCollider(KeyCode lastMovementKeyPressed)
    {
        float zRotation;

        switch (lastMovementKeyPressed)
        {
            case KeyCode.W: zRotation = 180;
                break;
            case KeyCode.S: zRotation = 0;
                break;
            case KeyCode.A: zRotation = -90;
                break;
            case KeyCode.D: zRotation = 90;
                break;
            default:
                Debug.LogError("last movement key pressed was not a movement key! wtf");
                zRotation = 45;
                break;
        }

        centerOfRotation.localEulerAngles = new Vector3(0, 0, zRotation);
    }

    public void Attack(KeyCode lastMovementKeyPressed)
    {
        RotateAttackCollider(lastMovementKeyPressed);

        playerDamager.ActivateColliderDuringAttackAnimation();
    }

}
 