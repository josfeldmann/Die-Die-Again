using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;






public class LevelData : MonoBehaviour {


    public enum UIState { PAUSE, WIN, GAME }

    public Level LevelInfo;

    public UIState u; 
    public static CheckPoint Spawnpoint;
    public static LevelData Instance;
    public static bool paused;
    public CheckPoint initialSpawnPoint;
    public GameObject Knight;
    public Color checkpointOnColor, checkPointOffColor;
    public float spawnheight = 2;
    public int NumDeaths = 0;
    public Text deathText, centerText, timeText;
    bool activePlayer = false;
    public string centerMessage = "Press E to respawn";
    public Tilemap tileMap;
    public TileBase tb;
    public ObjectDataBase odb;
    


    public float StartTime;
    public float EndTime;

    public GameObject NormalUI, PauseUI;
    public WinMenu winMenu;

    public void PlayerDied() {
        NumDeaths++;
        deathText.text = "Deaths: " + NumDeaths.ToString();
        centerText.text = centerMessage;
        activePlayer = false;
        CameraController.Instance.SetTarget(Spawnpoint.transform);
    }


    public void WinGame() {
        paused = true;
        Time.timeScale = 0;
        EndTime = Time.time - StartTime;
        NormalUI.SetActive(false);
        PauseUI.SetActive(false);
        winMenu.gameObject.SetActive(true);
        winMenu.UpdateWin();
    }

    public void SpawnNewPlayer() {
        GameObject.Instantiate(Knight, Spawnpoint.transform.position + (Vector3.up * spawnheight), Quaternion.identity);
        centerText.text = "";
        activePlayer = true;
    }


    public void LoadCustomLevel() {
        
        tileMap = GameObject.Find("Tilemap").GetComponent<Tilemap>();
        tileMap.ClearAllTiles();
        foreach (Vector3Int vec in GameInstance.data.tiles) {
            tileMap.SetTile(vec, tb);
        }

        foreach (Vector3Int vec in GameInstance.data.objects) {
           
            GameObject gem = GameObject.Instantiate(odb.odb[vec.z].editor, new Vector3(vec.x + 0.5f, vec.y + 0.5f, 0) , Quaternion.identity);
            if (vec.z == 0 && !foundflag) {
                gem.gameObject.name = "InitSpawnPoint";
                foundflag = true;
            }
        }
    }

    bool foundflag = false;

    // Use this for initialization
    void Start () {

        if (GameInstance.CurrentLevel != null && GameInstance.CurrentLevel.isCustom) {
            LoadCustomLevel();
        }

        Instance = this;
        Time.timeScale = 1;
        winMenu.gameObject.SetActive(false);
        


        Spawnpoint = initialSpawnPoint;
        if (Spawnpoint == null)
            Spawnpoint = GameObject.Find("InitSpawnPoint").GetComponent<CheckPoint>();

        Spawnpoint.TurnOn();
        SpawnNewPlayer();
        centerText.text = "";
        paused = false;
        PauseUI.SetActive(false);
        StartTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

        timeText.text = "Time: " + GameInstance.TimeFunction(Time.time - StartTime);

		if (!activePlayer && Input.GetButtonDown("Interact")) {
            SpawnNewPlayer();
        }

        if (Input.GetButtonDown("Restart")){

            Restart();
        }

        if (Input.GetButtonDown("Pause") && u != UIState.WIN) {
            Pause(!paused);
        }
	}


    public void LoadScene(string sname) {
        SceneManager.LoadScene(sname);
    }

    public void Pause(bool pause) {

        if (pause) {
            u = UIState.PAUSE;
            Time.timeScale = 0;
            PauseUI.SetActive(true);
            NormalUI.SetActive(false);
            winMenu.gameObject.SetActive(false);
        }
        else {
            u = UIState.GAME;
            Time.timeScale = 1; 
            PauseUI.SetActive(false);
            NormalUI.SetActive(true);
            winMenu.gameObject.SetActive(false);
        }

        paused = pause;
    }

    public void Restart() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
