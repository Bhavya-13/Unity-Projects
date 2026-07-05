using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
	public void loadlevel ()
	{
		SceneManager.LoadScene("Level01");
		PlayerPrefs.SetInt("Coins", CoinCounter.coinsCount);
	}

	public void QuitGame(){
		Application.Quit();
		Debug.Log("QUIT!");
		PlayerPrefs.SetInt("Coins", CoinCounter.coinsCount);
	}

	public void Menu ()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void Shop ()
	{
		SceneManager.LoadScene("Shop");
	}

	public void Back()
	{
		SceneManager.LoadScene("GameOver");
	}


}
