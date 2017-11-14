using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	public static GameControl instance;
	public GameObject gameOverText;
	public Text scoreText;
	public Text highScoreText;
	public bool gameOver = false;
	public float scrollSpeed = -3.5f;
	AudioSource birdAudio;
	public AudioClip scoreSound,dieSound;
	public int scoreDifferance = 0;
	public float spawnRate = 4f;

	private int score = 0;
	private int highScore = 0;
	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		} else if(instance != this) {
			Destroy(gameObject);
		}
	}

	void Start(){
		highScore = PlayerPrefs.GetInt ("highScore", highScore);
		highScoreText.text = "High Score: " + highScore.ToString ();
		birdAudio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver == true && Input.GetMouseButtonDown (0))
		{
			SceneManager.LoadScene("Main");
		}
	}

	public void BirdScored()
	{
		if (gameOver) {
			return;
		}
		score++;
		scoreDifferance++;
		if (scoreDifferance >= 10) {
			ChangeLabel ();
		}
		birdAudio.PlayOneShot (scoreSound);
		scoreText.text = "Score: " + score.ToString ();
	}

	public void BirdDied()
	{
		if (score > highScore) {
			highScore = score;
			PlayerPrefs.SetInt ("highScore", highScore);
		}
		birdAudio.PlayOneShot (dieSound);
		highScoreText.text = "High Score: " + highScore.ToString ();
		gameOverText.SetActive (true);
		gameOver = true;
	}
	public void ChangeLabel(){
		scrollSpeed = scrollSpeed - .5f;
		spawnRate = spawnRate/1.2f;
		scoreDifferance = 0;
		foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
		{
			if (obj.tag == "speed") {
				Rigidbody2D rb2d = obj.GetComponent<Rigidbody2D> ();
				rb2d.velocity = new Vector2 (scrollSpeed, 0);
			}
		}
	}

}
