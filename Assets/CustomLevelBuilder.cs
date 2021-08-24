using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using System.IO;
using UnityEngine.EventSystems;
using LitJson;


[System.Serializable]
public class JSONLevelData {
    public List<Vector3Int> tiles;

    public List<Vector3Int> objects;

    public string name;

    public int xbound, ybound, seconds, numberOfDeaths;

    public JSONLevelData() {
        xbound = 50;
        ybound = 20;

    }


}

[System.Serializable]
public struct PrefabInstance {
    int id;
    int x;
    int y;
    


    public PrefabInstance(int id1, float x1, float y1) {
        x = (int)x1;
        y = (int)y1;
        id = id1;
        
    }
}


public class CustomLevelBuilder: MonoBehaviour {

    enum BrushMode { TILE, PREFAB }

    public static CustomLevelBuilder instance;

    BrushMode currMode = BrushMode.TILE;


    GameObject[] holders;

    JSONLevelData data;
    public InputField textName, deathField, timeField;
    public List<Vector3Int> tiles;
    public List<Vector3Int> prefs;
    public Tilemap tilemap;

    int currObj;
    public ObjectDataBase obd;
    public GameObject ItemButtonPrefab, ItemList, SaveMenu;
    public SceneSwitcher sceneSwitcher;

    public int ObjectCount = 0;
    
    public TileBase dirt;

    GameObject activeObj;

    public void NeutralizeObj(GameObject gem) {
        if (gem.GetComponent<Rigidbody2D>() != null) gem.GetComponent<Rigidbody2D>().isKinematic = true;
        if (gem.GetComponent<BuildingBlock>() != null) gem.GetComponent<BuildingBlock>().enabled = false;
    }

    

    public void Start() {

        ItemList.SetActive(false);

        instance = this;
        Time.timeScale = 1;
        data = new JSONLevelData();
        tiles = new List<Vector3Int>();
        //tilemap.ClearAllTiles();

        tilemap.SetTile(Vector3Int.zero, dirt);

        for (int i = 0; i < data.xbound; i++)
            for (int j = 0; j < data.ybound; j++) {
                if (tilemap.GetTile(new Vector3Int(i, j, 0))) {
                    
                    tiles.Add(new Vector3Int(i,j,0));
                }
            }

       holders = new GameObject[obd.odb.Count];
        for (int i = 0; i < obd.odb.Count; i++) { 
            GameObject gem;
            holders[i] = GameObject.Instantiate(obd.odb[i].editor, Vector3.zero, Quaternion.identity, transform);
            gem = holders[i];
            NeutralizeObj(gem);
            gem.SetActive(false);
            gem = GameObject.Instantiate(ItemButtonPrefab, Vector3.zero, Quaternion.identity, ItemList.transform);
            if (holders[i].GetComponent<SpriteRenderer>() != null) {
                gem.GetComponent<ItemButton>().init(holders[i].GetComponent<SpriteRenderer>().sprite, i);
            } else {
                gem.GetComponent<ItemButton>().init(obd.odb[i].Backup, i);

            }


        }
        
    }

    public void ChangeObj(int b) {
        currObj = b;
        activeObj.SetActive(false);
        activeObj = holders[(int)b];
        activeObj.SetActive(true);
    }


    public void Update() {

        if (currMode == BrushMode.PREFAB && activeObj != null) {
            activeObj.transform.position = tilemap.CellToWorld(tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition))) + new Vector3(0.5f, 0.5f, 0);
        }

        if (Input.GetMouseButtonDown(0)) {

            if (EventSystem.current.IsPointerOverGameObject())    // is the touch on the GUI
            {
                // GUI Action
                return;
            }

            if (currMode == BrushMode.TILE) {

                Vector3Int vec = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                tilemap.SetTile(tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)), dirt);
                tiles.Add(vec);
            }
            else {

                GameObject gem = obd.odb[currObj].editor; 
                

                Vector3 place = tilemap.CellToWorld(tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)));

                prefs.Add(new Vector3Int((int)place.x, (int)place.y, (int)currObj));

                if (gem != null) {
                    gem = GameObject.Instantiate(gem, place + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
                    NeutralizeObj(gem);
                    

                }
            }
        }
        if (Input.GetMouseButtonDown(1)) {

            if (EventSystem.current.IsPointerOverGameObject())    // is the touch on the GUI
            {
                // GUI Action
                return;
            }


            if (currMode == BrushMode.TILE) {

                Vector3Int vec = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                tilemap.SetTile(tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition)), null);
                tiles.Remove(vec);
                
            }


        }
    }

    public void GoTile() {
        currMode = BrushMode.TILE;
        ItemList.SetActive(false);
        activeObj.SetActive(false);

    }

    public void GoPrefab() {
        currMode = BrushMode.PREFAB;
        ItemList.SetActive(true);
        activeObj = holders[(int)currObj];
        activeObj.SetActive(true);

    }

    public void ShowSaveMenu() {
        SaveMenu.SetActive(true);
    }


    public void ConvertData() {

        data.name = textName.text;
        data.tiles = tiles;
        data.numberOfDeaths = int.Parse(deathField.text);
        data.seconds = int.Parse(timeField.text);
        data.objects = prefs;
        string LevelPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/DieDieAgain/Custom_Levels";

        if (!Directory.Exists(LevelPath)) {
            Directory.CreateDirectory(LevelPath);
        }
        
        string Data = JsonUtility.ToJson(data);

        if (textName.text != "")
        File.WriteAllText(LevelPath + "/" + textName.text + ".json", Data);
        sceneSwitcher.LoadScene("MainMenu");
    }

}
