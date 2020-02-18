using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] PlayerRigidbodyWrapper rigidbody2DWrapper;
    DirectionCalculator directionCalculator;
    bool singleMovementKeyIsPressed = false;

    private void Start()
    {
        directionCalculator = new SingleKeyDirectionCalculator();
    }

    public void InformIfJustOneMovementKeyIsPressed(bool singleMovementKeyIsPressed)
    {
        this.singleMovementKeyIsPressed = singleMovementKeyIsPressed;
    }

    public void Walk(bool w, bool s, bool a, bool d)
    {
        if (singleMovementKeyIsPressed)
        {
            Vector2 direction = directionCalculator.CalculateDirection(w, s, a, d);

            Vector2 moveIntention = direction * speed;

            rigidbody2DWrapper.RegisterMoveIntention(moveIntention, "playerWalk");
        }
    }

}
