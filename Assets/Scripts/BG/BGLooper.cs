using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

	public float speed;

	private Vector2 _offset = Vector2.zero;

	private Material _mat;

	// Use this for initialization
	void Start () {
		_mat = GetComponent<Renderer> ().material;
		_offset = _mat.GetTextureOffset ("_MainTex");
	}
	
	// Update is called once per frame
	void Update () {
		_offset.y += speed * Time.deltaTime;
		_mat.SetTextureOffset ("_MainTex", _offset);
	}
}
