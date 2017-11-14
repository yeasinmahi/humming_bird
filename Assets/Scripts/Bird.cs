using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

	public float upForce = 200f;

	private bool isDead = false;
	private Rigidbody2D rb2d;
	private Animator anim;
	AudioSource flapAudio;
	public AudioClip flapSound;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		flapAudio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead == false)
		{
			if(Input.GetMouseButtonDown(0))
			{
				rb2d.velocity = Vector2.zero;
				rb2d.AddForce(new Vector2(0,upForce));
				anim.SetTrigger("Flap");
				flapAudio.PlayOneShot (flapSound); 
			}
		}
	}

	void OnCollisionEnter2D()
	{
		rb2d.velocity = Vector2.zero;
		isDead = true;
		anim.SetTrigger("Die");
		GameControl.instance.BirdDied ();
	}
}
