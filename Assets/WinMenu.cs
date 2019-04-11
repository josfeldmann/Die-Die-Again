using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{

    public Text pardeath, partime, yourtime, yourdeath;
    // Start is called before the first frame update


    public void UpdateWin() {
        pardeath.text = "Par Deaths: " + LevelData.Instance.LevelInfo.numberOfDeaths.ToString();
        yourdeath.text = "Your Deaths: " + LevelData.Instance.NumDeaths.ToString();

        yourtime.text = "Your Time: " + GameInstance.TimeFunction(LevelData.Instance.EndTime);
        partime.text = "Par Time: " + GameInstance.TimeFunction(LevelData.Instance.LevelInfo.seconds);
    }
}
