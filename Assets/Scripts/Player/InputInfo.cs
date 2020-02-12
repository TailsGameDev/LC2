using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputInfo
{
    bool w, a, s, d;
    bool attackInput;
    KeyCode lastMovementKeyPressed;

    public InputInfo(KeyCode previousLastMovementKeyPressed)
    {
        w = Input.GetKey("w");
        s = Input.GetKey("s");
        a = Input.GetKey("a");
        d = Input.GetKey("d");

        attackInput = Input.GetMouseButtonDown(0);

        lastMovementKeyPressed = FindLastMovementKeyPressed(previousLastMovementKeyPressed);
    }

    KeyCode FindLastMovementKeyPressed(KeyCode previousLast)
    {
        KeyCode last;

        if (Input.GetKey(previousLast))
        {
            last = previousLast;
        } else if ( NoMovementKeyIsPressed() )
        {
            last = previousLast;
        }
        else
        {
            last = GetSomeMovementKeyPressed();
        }

        return last;
    }

    bool NoMovementKeyIsPressed()
    {
        return ! (w || s || a || d);
    }

    KeyCode GetSomeMovementKeyPressed()
    {
        KeyCode last;

        if (w)
        {
            last = KeyCode.W;
        }
        else if (a)
        {
            last = KeyCode.A;
        }
        else if (d)
        {
            last = KeyCode.D;
        }
        else
        {
            last = KeyCode.S;
        }

        return last;
    }

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

    public bool GetW()
    {
        return w;
    }
    public bool GetS()
    {
        return s;
    }
    public bool GetA()
    {
        return a;
    }
    public bool GetD()
    {
        return d;
    }

    public bool GetAttackInput()
    {
        return attackInput;
    }

    public KeyCode GetLastMovementKeyPressed()
    {
        return lastMovementKeyPressed;
    }
}
