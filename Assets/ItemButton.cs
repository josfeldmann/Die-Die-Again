using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public Image Sprite;
    public int b;

    public void init(Sprite s, int b1) {
        
        
            Sprite.sprite = s;
        
        b = b1;
    }

    public void ChangeItem() {
        CustomLevelBuilder.instance.ChangeObj(b);
    }




}
