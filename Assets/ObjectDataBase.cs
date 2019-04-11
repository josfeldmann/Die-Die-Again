using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectDatabase", menuName = "Backend", order = 1)]
public class ObjectDataBase : ScriptableObject
{
    public List<ENUMObjPair> odb;
    
}

[System.Serializable]
public class ENUMObjPair {
    public BuildObj buildObj;
    public GameObject editor;
    public Sprite sprite;
}
