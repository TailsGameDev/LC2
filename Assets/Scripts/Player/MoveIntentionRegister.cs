using UnityEngine;

class MoveIntentionRegister
{
    Vector2 moveIntention;
    string callerClassName;

    public MoveIntentionRegister(Vector2 intention, string caller)
    {
        this.moveIntention = intention;
        this.callerClassName = caller;
    }

    public Vector2 GetMoveIntention()
    {
        return moveIntention;
    }
}