using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Collider2D attackCollider;
    [SerializeField] Transform centerOfRotation;

    [SerializeField] float attackDuration;

    private void Start()
    {
        attackCollider.gameObject.SetActive(false);
    }

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

        CancelCurrentAttacks();

        StartCoroutine(ActivateAndDeactivateCollider());
    }

    void CancelCurrentAttacks()
    {
        attackCollider.gameObject.SetActive(false);
        StopAllCoroutines();
    }

    IEnumerator ActivateAndDeactivateCollider()
    {
        yield return new WaitForSeconds(Time.deltaTime * 6);
        attackCollider.gameObject.SetActive(true);
        yield return new WaitForSeconds(Time.deltaTime * 6);
        attackCollider.gameObject.SetActive(false);
    }
}
 