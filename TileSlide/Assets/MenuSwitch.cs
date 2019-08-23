using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSwitch : MonoBehaviour
{
    public void goToMainMenu ()
    {
        SceneManager.LoadScene("Menu");
        GameObject mainMenu = GameObject.Find("MainMenu");
        mainMenu.SetActive(true);
        GameObject settingsMenu = GameObject.Find("SettingsMenu");
        settingsMenu.SetActive(false);
    }

	public void playGame()
	{
		SceneManager.LoadScene ("SlideGame");
	}
}
