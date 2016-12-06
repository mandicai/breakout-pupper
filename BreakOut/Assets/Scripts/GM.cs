using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {

	public int lives = 3;
	public int bricks = 20;
	public float resetDelay = 1f;
	public Text livesText;
	public GameObject gameOver;
	public GameObject youWon;
	//public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject deathParticles;
	// Access only via this class, not any other classes 
	// Only one instance of the Game Manager ever 
	// Makes it easier to directly access variables within GM 
	public static GM instance = null;
	public Vector3 position = new Vector3 (-13.71675f,5.911882f,4.62829f);
	private GameObject clonePaddle;
	//private GameObject cloneBricks;

	// Use this for initialization
	void Start () {
		// Do we have a GM yet?
		if (instance == null)
			// If not, set it to this
			instance = this;
		// If there is already a GM, destroy the current one
		else if (instance != this)
			Destroy (gameObject);

		Setup ();
	}

	public void Setup() {
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;
		//cloneBricks = Instantiate (bricksPrefab, transform.position, Quaternion.identity) as GameObject;
		Debug.Log (transform.position);
	}

	void CheckGameOver() {
		if (bricks == 0) {
			youWon.SetActive (true);
			// Time.timescale
			// The scale at which the time is passing 
			// If timescale is 0.25, the time is passing 2x slower than realtime
			Time.timeScale = 0.25f;
			// Reload scene and restart the game 
			Invoke ("Reset", resetDelay);
		}

		if (lives < 1) {
			gameOver.SetActive (true);
			Time.timeScale = 0.25f;
			// Reload scene and restart the game
			Invoke ("Reset", resetDelay);
		}
	}

	void Reset() {
		Time.timeScale = 1f;
		Application.LoadLevel (Application.loadedLevel);
	}

	public void LoseLife() {
		lives--;
		livesText.text = "Lives: " + lives;
		//Quaternion.identity = no rotation
		Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy (clonePaddle);
		Invoke ("SetupPaddle", resetDelay);
		CheckGameOver ();
	}

	void SetupPaddle() {
		clonePaddle = Instantiate (paddle, transform.position, Quaternion.identity) as GameObject;
	}

	public void DestroyBrick() {
		bricks--;
		CheckGameOver ();
	}
	
	// Update is called once per frame
	// Typically update is not used in a Game Manager!
	void Update () {
	
	}
}
