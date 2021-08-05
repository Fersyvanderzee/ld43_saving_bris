using System.Collections;
using UnityEngine;

public class PlayerMover : MonoBehaviour {

	public float speed;
	public float consumptionRate;

	FuelSystem fuelSystem;

	private Rigidbody2D rb2d;

		
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();

		fuelSystem = GetComponent<FuelSystem>();
	//Add this line of code upon pressing the throttle key


	}
	
	// Update is called once per frame
	void Update () {

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		rb2d.AddForce (movement * speed);

		if(Input.GetAxis ("Horizontal") < 0)
		{
			fuelSystem.fuelConsumptionRate = speed * consumptionRate;
		fuelSystem.ReduceFuel();
		}
		
		if(Input.GetAxis ("Horizontal") > 0)
		{
			fuelSystem.fuelConsumptionRate = speed * consumptionRate;
		fuelSystem.ReduceFuel();
		}
		

		if(Input.GetAxis("Vertical") < 0)
		{
			fuelSystem.fuelConsumptionRate = speed * consumptionRate;
		fuelSystem.ReduceFuel();
		}

		if(Input.GetAxis("Vertical") > 0)
		{
			fuelSystem.fuelConsumptionRate = speed * consumptionRate;
		fuelSystem.ReduceFuel();
		}
	
	}

}


