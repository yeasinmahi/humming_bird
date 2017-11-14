using UnityEngine;
using System.Collections;

public class Column : MonoBehaviour {
	// Use this for initialization
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<Bird>() != null)
		{
			GameControl.instance.BirdScored();
		}
	}
}
