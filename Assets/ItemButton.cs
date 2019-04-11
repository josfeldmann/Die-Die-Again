using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public Image Sprite;
    public BuildObj b;

    public void init(Sprite s, BuildObj b1) {
        Sprite.sprite = s;
        b = b1;
    }

    public void ChangeItem() {
        CustomLevelBuilder.instance.ChangeObj(b);
    }




}
