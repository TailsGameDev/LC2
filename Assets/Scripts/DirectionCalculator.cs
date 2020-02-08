using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to use Strategy Design Patter

public abstract class DirectionCalculator
{
    public abstract Vector2 CalculateDirection(bool w, bool s, bool a, bool d);
}

public class MultipleKeyDirectionCalculator : DirectionCalculator
{
    public override Vector2 CalculateDirection(bool w, bool s, bool a, bool d)
    {
        Vector2 direction = new Vector2();

        if (w)
        {
            direction += new Vector2(0, 1);
        }
        if (s)
        {
            direction += new Vector2(0, -1);
        }
        if (a)
        {
            direction += new Vector2(-1, 0);
        }
        if (d)
        {
            direction += new Vector2(1, 0);
        }

        return direction;
    }
}

public class SingleKeyDirectionCalculator : DirectionCalculator
{
    public override Vector2 CalculateDirection(bool w, bool s, bool a, bool d)
    {
        Vector2 direction = new Vector2();

        if (w)
        {
            direction += new Vector2(0, 1);
        }
        else if (s)
        {
            direction += new Vector2(0, -1);
        }
        else if (a)
        {
            direction += new Vector2(-1, 0);
        }
        else //d
        {
            direction += new Vector2(1, 0);
        }

        return direction;
    }
}
