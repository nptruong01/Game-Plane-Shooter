using UnityEngine;
using System.Collections;

public class BGScaler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var worldHeight = Camera.main.orthographicSize * 2;//10
		var worldWidth = worldHeight * Screen.width/Screen.height;//10 * 214 / 356
		transform.localScale = new Vector3(worldWidth,worldHeight,0);
	}
}
