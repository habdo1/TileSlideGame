using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSize : MonoBehaviour
{
    int gridSize = 4;
    Text gridSizeText;
    public Slider slider;

    void Start ()
    {
        gridSizeText = GetComponent<Text> ();
        gridSizeText.text = GameData.GridSize.ToString();
        gridSize = GameData.GridSize;
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        slider.value = GameData.GridSize;
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
