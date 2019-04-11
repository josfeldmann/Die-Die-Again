using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameInstance 
{
    public static Level CurrentLevel;
    public static JSONLevelData data;

    public static string TimeFunction(float seconds) {
        return ((int)seconds / 60).ToString() + ":" + ((int)seconds % 60).ToString().PadLeft(2, '0');
    }


}
