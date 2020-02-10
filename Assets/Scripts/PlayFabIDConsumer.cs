using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFabIDConsumer
{

    private static string playFabId;

    public static void SetPlayFabId(string id)
    {
        playFabId = id;
    }

    protected string GetPlayFabId()
    {
        return playFabId;
    }
}
