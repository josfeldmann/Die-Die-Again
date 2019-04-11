using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildObj { FLAG, SPIKES, CRATE, PLATFORM, DOOR, MOVINGPLATFORM, BUZZSAW, GRAIL }

public class BuildingBlock : MonoBehaviour
{

    public BuildObj buildObj;
    public int editorID;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
