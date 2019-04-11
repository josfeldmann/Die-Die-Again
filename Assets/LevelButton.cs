using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{

    public Text Time, Deaths, Name;
    public Button b;
    Level level;
    JSONLevelData data;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadLevel(Level l) {
        level = l;
        Name.text = l.LevelName;
        Time.text = "Goal Time: " + ((int)l.seconds/60).ToString() + ":" + (l.seconds % 60).ToString().PadLeft(2, '0');
        Deaths.text = "Goal Deaths: " + l.numberOfDeaths.ToString();
        b.onClick.AddListener(GoLevel);

    }


    public void LoadLevel(JSONLevelData l) {
        data = l;
        level = new Level();
        level.numberOfDeaths = l.numberOfDeaths;
        level.seconds = l.seconds;
        level.sceneName = l.name;
        level.LevelName = l.name;
        level.isCustom = true;
        Name.text = l.name;
        Time.text = "Goal Time: " + ((int)l.seconds / 60).ToString() + ":" + (l.seconds % 60).ToString().PadLeft(2, '0');
        Deaths.text = "Goal Deaths: " + l.numberOfDeaths.ToString();
        b.onClick.AddListener(GoLevel);

    }


    void GoLevel() {
        GameInstance.CurrentLevel = level;
        GameInstance.data = data;
        if(!level.isCustom)
        SceneManager.LoadScene(level.sceneName);
        else {
            SceneManager.LoadScene("CustomLevel");
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
