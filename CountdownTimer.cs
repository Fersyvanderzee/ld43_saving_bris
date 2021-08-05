using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {

	public float timeLeft = 180.00f;
	public Text countdown;
	public Text loseTextTime;

	// Use this for initialization
	void Start () {
		StartCoroutine("LoseTime");
		Time.timeScale = 1;
		loseTextTime.text = "";
		
		
	}
	
	// Update is called once per frame
	void Update () {
		countdown.text = ("" + timeLeft);
		if (timeLeft <= 0) {
			countdown.text = ("");
			loseTextTime.text = "Out of time! \n\n Press 'R' to restart";
			FindObjectOfType<GameManager>().EndGame();

		}

	}

	IEnumerator LoseTime()
	{
		while(true)
		{
			yield return new WaitForSeconds(1);
			timeLeft--;
		}
	}

}


