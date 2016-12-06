using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bricks : MonoBehaviour {

	public GameObject brickParticle;
	//public Vector3 offset = new Vector3 (0f, 0f, 50f);
	public GameObject doge;

	void OnCollisionEnter (Collision other) {
		Instantiate (brickParticle, transform.position, Quaternion.identity);
		GM.instance.DestroyBrick ();
		Destroy (gameObject);
		//Instantiate (doge, transform.position + offset, Quaternion.identity);
		Vector3 position = new Vector3 (Random.Range (0f, 10.0f), Random.Range (0f, 10.0f), 2.0f);
		Instantiate (doge, position, Quaternion.identity);
	}
		
}
