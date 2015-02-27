using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	private Node[,] grid;
	public Vector2 gridSize;
	public float nodeRadius;
	private float nodeDiameter;

	public LayerMask layer;
	public int xNum,yNum;

	// Use this for initialization
	void Start () {
		nodeDiameter = nodeRadius * 2;
		xNum = Mathf.RoundToInt (gridSize.x / nodeDiameter);
		yNum = Mathf.RoundToInt (gridSize.y / nodeDiameter);
		grid = new Node[xNum,yNum];
		CreateGrid ();
	}

	private void CreateGrid(){

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
