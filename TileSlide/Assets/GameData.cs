using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    private static int imgIndex = 10;
    public static int ImgIndex 
    {
        get 
        {
            return imgIndex;
        }
        set 
        {
            imgIndex = value;
        }
    }


    private static int gridSize = 4;
    public static int GridSize 
    {
        get 
        {
            return gridSize;
        }
        set 
        {
            gridSize = value;
        }
    }

}
