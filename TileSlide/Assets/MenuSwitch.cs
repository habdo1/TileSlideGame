using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSwitch : MonoBehaviour
{
    public void goToMainMenu ()
    {
        SceneManager.LoadScene("Menu");
    }

	public void playGame()
	{
		SceneManager.LoadScene ("SlideGame");
	}
}
