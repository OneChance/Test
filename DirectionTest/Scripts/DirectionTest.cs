using UnityEngine;
using System.Collections;

public class DirectionTest : MonoBehaviour {

	public Transform dest;
	float res;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay(transform.position,transform.up);
		Debug.DrawRay(transform.position,(dest.position-transform.position).normalized);

		res = Vector3.Dot(transform.up,(dest.position-transform.position).normalized);

	}

	void OnGUI(){
		GUILayout.Label(res.ToString(),GUILayout.Width(Screen.width));
		GUI.skin.label.fontSize = 40;
	}
}
