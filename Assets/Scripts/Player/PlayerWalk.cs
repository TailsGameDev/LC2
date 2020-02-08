using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] PlayerRigidbodyWrapper rigidbody2DWrapper;
    DirectionCalculator directionCalculator;

    private void Start()
    {
        directionCalculator = new SingleKeyDirectionCalculator();
    }

    public void Walk(bool w, bool s, bool a, bool d)
    {
        if (PlayerInput.IsJustOneMovementKeyPressed())
        {
            Vector2 direction = directionCalculator.CalculateDirection(w, s, a, d);

            Vector2 moveIntention = direction * speed;

            rigidbody2DWrapper.RegisterMoveIntention(moveIntention, "playerWalk");
        }
    }

}
