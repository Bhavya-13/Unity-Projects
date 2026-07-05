using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
	public static int scoreValue;

	public Text score;

	public Text highscore;

	private void Start()
	{
		score = GetComponent<Text>();
		highscore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0);
	}

	private void Update()
	{
		score.text = "Score: " + scoreValue;
		if (scoreValue > PlayerPrefs.GetInt("HighScore", 0))
		{
			PlayerPrefs.SetInt("HighScore", scoreValue);
			highscore.text = "HighScore: " + scoreValue;
		}
	}
}
