using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


[System.Serializable]
public class Level {

    public string sceneName;
    public string LevelName;
    public bool isCustom;
    public TextAsset customLevel;
    public int numberOfDeaths;
    public int seconds;

}

public class LevelManager : MonoBehaviour
{

    public List<Level> MainLevels;
    public List<Level> CustomLevels;
    public GameObject ButtonPrefab, MainLevelObj, CustomLevelObj;
    string LevelPath = "";
    
    
    void BuildLevelList() {
        LevelPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/DieDieAgain/Custom_Levels";
        foreach (Level l in MainLevels) {
            GameObject gem = GameObject.Instantiate(ButtonPrefab, MainLevelObj.transform);
            gem.GetComponent<LevelButton>().LoadLevel(l);
        }
        if (!Directory.Exists(LevelPath)) {
            Directory.CreateDirectory(LevelPath);
        } else {
            string[] filePaths = Directory.GetFiles(LevelPath);

            foreach (string filePath in filePaths) {
                JSONLevelData data = JsonUtility.FromJson<JSONLevelData>(File.ReadAllText(filePath));
                GameObject gem = GameObject.Instantiate(ButtonPrefab, CustomLevelObj.transform);
                gem.GetComponent<LevelButton>().LoadLevel(data);
            }
        }

        }

    // Start is called before the first frame update
    void Start()
    {
        BuildLevelList();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
