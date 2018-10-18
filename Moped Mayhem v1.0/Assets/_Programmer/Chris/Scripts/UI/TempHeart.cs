using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TempHeart : MonoBehaviour {

	public GameObject[] hearts;
	public int currentLives;

	private void Start()
	{
		currentLives = hearts.Length;
	}

	public void TakeDamage()
	{
		currentLives--;

		if (currentLives >= 0)
		{
			hearts[currentLives].SetActive(false);
		}
		else
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

			currentLives = hearts.Length;
			foreach (GameObject heart in hearts)
			{
				heart.SetActive(true);
			}
		}
	}
}
