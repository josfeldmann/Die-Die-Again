using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemCategory { OBJECTIVES, PUSHABLE, HAZARDS, PLATFORMS, COSMETIC }

[CreateAssetMenu(fileName = "ObjectDatabase", menuName = "Backend", order = 1)]
public class ObjectDataBase : ScriptableObject
{
    public List<ENUMObjPair> odb;
    
}

[System.Serializable]
public class ENUMObjPair {
    public string name;
    public Sprite Backup;
    public GameObject editor;
    public ItemCategory category;
}
