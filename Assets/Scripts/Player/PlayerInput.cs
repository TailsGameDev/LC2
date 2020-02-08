using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [SerializeField] PlayerWalk playerWalk;
    [SerializeField] PlayerAnimationManager playerAnim;

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
        bool w = Input.GetKey("w");
        bool s = Input.GetKey("s");
        bool a = Input.GetKey("a");
        bool d = Input.GetKey("d");

        playerWalk.Walk(w, s, a, d);
        playerAnim.AnimateWalk(w, s, a, d);
    }

}
