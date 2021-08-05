
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	bool gameHasEnded = false;

	public float restartDelay = 4f;
	

	public void EndGame ()
	{
		if(gameHasEnded == false)
		{
			gameHasEnded = true;
			Invoke("Restart", restartDelay);

		}
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.R))
		Restart();
		if(Input.GetKeyDown(KeyCode.Q))
		Quit();
	}
	


	void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	void Quit()
	{
		Application.Quit();
	}

}
