using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
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
