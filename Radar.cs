using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour {

	public GameObject[] trackedObjects;
	List<GameObject> radarObjects;
	public GameObject radarPrefab;
	List<GameObject> borderObjects;
	public float switchDistance;
	public Transform helpTransform;

	// Use this for initialization
	void Start () {
		createRadarObjects();
	}
	
	// Update is called once per frame
	void Update ()
	{
		for(int i = 0; i < radarObjects.Count; i++)
		{
			if(Vector3.Distance(radarObjects[i].transform.position, transform.position) > switchDistance)
			{
				//switch to borderObjects
				helpTransform.LookAt(radarObjects[i].transform);
				borderObjects[i].transform.position = transform.position + switchDistance * helpTransform.forward;
				borderObjects[i].layer = LayerMask.NameToLayer("Radar");
				radarObjects[i].layer = LayerMask.NameToLayer("Invisible");
				
			} else {
				//switch back to radarObjects
				borderObjects[i].layer = LayerMask.NameToLayer("Invisible");
				radarObjects[i].layer = LayerMask.NameToLayer("Radar");

			}
		}
	}

	void createRadarObjects()
	{
		radarObjects = new List<GameObject>();
		borderObjects = new List<GameObject>();
		foreach(GameObject f in trackedObjects)
		{
			GameObject r = Instantiate(radarPrefab, f.transform.position, Quaternion.identity) as GameObject;
			radarObjects.Add(r);
			GameObject j = Instantiate(radarPrefab, f.transform.position, Quaternion.identity) as GameObject;
			borderObjects.Add(j);
		}
	}
}
