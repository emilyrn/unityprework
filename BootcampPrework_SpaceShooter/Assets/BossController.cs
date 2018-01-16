using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

	float totaltime=0;
	private Rigidbody rb;
	public Vector3 spawnValues;
	public float speed;
	float width =5;
	float height=5;
	public float startWait;

	void Start ()
	{
		StartCoroutine (bossWave ());

	}

	IEnumerator bossWave(){
		yield return new WaitForSeconds(startWait);
		Vector3 spawnPosition = new Vector3 (spawnValues.x, spawnValues.y, spawnValues.z);
	}
	
	// Update is called once per frame
	void Update () {
		totaltime += Time.deltaTime;

		float x= Mathf.Cos (totaltime)*width;
		float y = 0;
		float z = Mathf.Sin (totaltime)*height;

		transform.position = new Vector3 (x, y, z);
	}
}
