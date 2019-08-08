using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSize : MonoBehaviour
{
    public int gridSize = 4;
    Text gridSizeText;

    void Start ()
    {
        gridSizeText = GetComponent<Text> ();
    }
    public void updateGridSize (float newValue)
    {
        gridSizeText.text = Mathf.RoundToInt(newValue).ToString();
        gridSize = (int) newValue;
        print ("Updating gridsize to " + gridSize);
        GameData.GridSize = gridSize;
        print ("Grid size: " + GameData.GridSize);
    }
}
