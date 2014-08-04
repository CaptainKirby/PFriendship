﻿using UnityEngine;
using System.Collections;

public class PlayerShot : MonoBehaviour {
	public float dmgToEnemy = 0.5f;
	public float backlashForce = 5f;
	public float backlashDuration = 0.2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "enemy")
		{
			col.gameObject.GetComponent<Enemy>().health -= dmgToEnemy;
			StartCoroutine("Backlash", col);
//			Destroy (this.gameObject);
//			Debug.Log ("TEST");
		}

	}

	IEnumerator Backlash(Collider col)
	{
//		while(true)
//		{
		col.rigidbody.isKinematic = false;
		col.rigidbody.AddForce(this.transform.position - col.transform.position * backlashForce, ForceMode.Impulse);
		yield return new WaitForSeconds(backlashDuration);
		col.rigidbody.isKinematic = true;
//		}
	}
}