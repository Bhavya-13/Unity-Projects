using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	public void PlayAgain()
	{
		SceneManager.LoadScene("Game");
		Score.scoreValue = 0;
	}

	public void Mainmenu()
	{
		SceneManager.LoadScene("Menu");
	}
}
