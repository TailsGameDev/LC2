using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [SerializeField] PlayerWalk playerWalk;
    [SerializeField] PlayerAnimationManager playerAnim;

    KeyCode lastMovementKeyPressed;

    bool w, s, a, d;

    public static bool IsJustOneMovementKeyPressed()
    {
        bool w = Input.GetKey("w");
        bool s = Input.GetKey("s");
        bool a = Input.GetKey("a");
        bool d = Input.GetKey("d");

        bool vertical = w ^ s;
        bool horizontal = a ^ d;
        bool isSingleKey = vertical ^ horizontal;

        return isSingleKey;
    }

    void Update()
    {
        w = Input.GetKey("w");
        s = Input.GetKey("s");
        a = Input.GetKey("a");
        d = Input.GetKey("d");

        playerWalk.Walk(w, s, a, d);
        playerAnim.AnimateWalk(w, s, a, d);
    }

    void StoreLastMovementKeyPressed()
    {
        if (w)
        {
            lastMovementKeyPressed = KeyCode.W;
        } else if (s)
        {
            lastMovementKeyPressed = KeyCode.S;
        } else if (a)
        {
            lastMovementKeyPressed = KeyCode.A;
        } else if (d)
        {
            lastMovementKeyPressed = KeyCode.D;
        }
    }
}
