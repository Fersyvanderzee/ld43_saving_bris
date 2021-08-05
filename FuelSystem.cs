using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FuelSystem : MonoBehaviour {

	public float startFuel; //starting fuel
	public float maxFuel = 100f;
	public float fuelConsumptionRate;
	public Slider fuelIndicatorSld;
	public Text fuelIndicatorTxt;
	public PlayerMover movement;
	public Text countText;
	public Text winText;
	public Text loseTextFuel;

	public float timeLeft = 180.00f;
	public Text countdown;
	public Text loseTextTime;

	private int count;

	// Use this for initialization
	void Start () {
		StartCoroutine("LoseTime");
		Time.timeScale = 1;
		loseTextTime.text = "";

		// cap the fuel
		if(startFuel > maxFuel)
			startFuel = maxFuel;
		fuelIndicatorSld.maxValue = maxFuel;
		count = 0;
		SetCountText();
		winText.text = "";
		UpdateUI();
		loseTextFuel.text = "";
		loseTextTime.text = "";
	}

	public void ReduceFuel()
	{
		//reduce the fuel level and update the UI
		startFuel -= Time.deltaTime * fuelConsumptionRate;
		UpdateUI();
	} 

	void UpdateUI()
	{
		fuelIndicatorSld.value = startFuel;
		fuelIndicatorTxt.text = "Fuel: " + startFuel.ToString("0") + " %";

		if(startFuel <=0)
		{
			startFuel = 0;
			fuelIndicatorTxt.text = "0%";
			loseTextFuel.text = "Out of fuel! \n\n Press 'R' to restart";
			FindObjectOfType<GameManager>().EndGame();

			movement.enabled = false;
		}
	}

	void Update ()
	{
		countdown.text = ("" + timeLeft);
		if (timeLeft <= 0) {
			countdown.text = ("");
			loseTextTime.text = "Out of time! \n\n Press 'R' to restart";
			FindObjectOfType<GameManager>().EndGame();

			movement.enabled = false;
		}

	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Fuel"))
		{
			other.gameObject.SetActive(false);
			startFuel += 20f;
			if(startFuel > maxFuel)
				startFuel = maxFuel;
			UpdateUI();
			
		}

		if (other.gameObject.CompareTag("Resource"))
		{
			
			count = count + 1;
            SetCountText();
			Destroy(other.gameObject);
			UpdateUI();
			
		}

	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.CompareTag("Fuel Station"))
		{
			startFuel += Time.deltaTime * 10f;
			if(startFuel > maxFuel)
			{
				startFuel = maxFuel;
			}
			UpdateUI();
		}
	}

	void SetCountText()
	{
		countText.text = count.ToString();
		if (count >= 10)
		{
			winText.text = "Congratulations! You saved the people of Bris!\n\n Thank you for playing! Press 'Q' to quit \n or 'R' to play again.";
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
