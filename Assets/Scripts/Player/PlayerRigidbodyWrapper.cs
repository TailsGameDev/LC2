using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// to ease debug, this class register each intention movement and the caller name

public class PlayerRigidbodyWrapper : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;

    List<MoveIntentionRegister> registeredMoveIntentions = new List<MoveIntentionRegister>();

    public void RegisterMoveIntention(Vector2 intention, string callerClassName)
    {
        registeredMoveIntentions.Add(new MoveIntentionRegister(intention, callerClassName));
    }

    private void LateUpdate()
    {
        rb2d.velocity = CalculateMoveIntention();
        registeredMoveIntentions = new List<MoveIntentionRegister>();
    }

    Vector2 CalculateMoveIntention()
    {
        Vector2 moveIntentionsSum = Vector2.zero;
        foreach(MoveIntentionRegister intentionRegister in registeredMoveIntentions)
        {
            moveIntentionsSum += intentionRegister.GetMoveIntention();
        }
        return moveIntentionsSum;
    }
}
