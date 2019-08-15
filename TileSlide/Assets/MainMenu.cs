using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public Texture2D[] images = new Texture2D[10];

	public void playGame()
	{
		SceneManager.LoadScene ("SlideGame");
	}
}