using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorXSprites : MonoBehaviour
{
    public  SpriteRenderer spriteX1;
    public  SpriteRenderer spriteX2;
    public  SpriteRenderer spriteX3;
    void Start()
    {
        resetColors();
    }

  public  void setColorRed(int i)
    {
        if(i==1) spriteX1.color = new Color(1, 0, 0, 1);
        if (i == 2) spriteX2.color = new Color(1, 0, 0, 1);
        if (i == 3) spriteX3.color = new Color(1, 0, 0, 1);
    }

    public void resetColors()
    {
        spriteX1.color = new Color(0, 1, 1, 1);
        spriteX2.color = new Color(0, 1, 1, 1);
        spriteX3.color = new Color(0, 1, 1, 1);
        
    }

}
