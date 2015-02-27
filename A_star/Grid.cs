using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour
{

		private Node[,] grid;
		public Vector2 gridSize;
		public float nodeRadius;
		private float nodeDiameter;
		public LayerMask whatLayer;
		public int gridCntX, gridCntY;
		public Transform player;
		public List<Node> path;

		public Node GetFromPosition (Vector3 position)
		{
				float percentX = (position.x - transform.position.x + gridSize.x / 2) / gridSize.x;
				float percentY = (position.z - transform.position.z + gridSize.y / 2) / gridSize.y;
				
				percentX = Mathf.Clamp01 (percentX);
				percentY = Mathf.Clamp01 (percentY);

				int x = Mathf.RoundToInt ((gridCntX - 1) * percentX);
				int y = Mathf.RoundToInt ((gridCntY - 1) * percentY);

				return grid [x, y];
		}

		// Use this for initialization
		void Start ()
		{
				nodeDiameter = nodeRadius * 2;
				gridCntX = Mathf.RoundToInt (gridSize.x / nodeDiameter);
				gridCntY = Mathf.RoundToInt (gridSize.y / nodeDiameter);
				grid = new Node[gridCntX, gridCntY];

				CreateGrid ();
		}

		void CreateGrid ()
		{
				Vector3 startPoint = transform.position - gridSize.x / 2 * Vector3.right - gridSize.y / 2 * Vector3.forward;
				for (int i=0; i<gridCntX; i++) {
						for (int j=0; j<gridCntY; j++) {
								Vector3 worldPos = startPoint + Vector3.right * (i * nodeDiameter + nodeRadius) + Vector3.forward * (j * nodeDiameter + nodeRadius);
								bool walkable = !Physics.CheckSphere (worldPos, nodeRadius, whatLayer);			
								grid [i, j] = new Node (walkable, worldPos, i, j);
						}
				}
		}

		void OnDrawGizmos ()
		{
				Gizmos.DrawWireCube (transform.position, new Vector3 (gridSize.x, 1, gridSize.y));
				if (grid == null)
						return;
			
				Node playerNode = GetFromPosition (player.position);

				foreach (var node in grid) {
						Gizmos.color = node._canWalk ? Color.white : Color.red;
						Gizmos.DrawCube (node._worldPos, Vector3.one * (nodeDiameter - .1f));
				}

				if (path != null) {
						foreach (var node in path) {
								Gizmos.color = Color.black;
								Gizmos.DrawCube (node._worldPos, Vector3.one * (nodeDiameter - .1f));
						}
				}

				if (playerNode != null && playerNode._canWalk) {
						Gizmos.color = Color.cyan;
						Gizmos.DrawCube (playerNode._worldPos, Vector3.one * (nodeDiameter - .1f));
				}
		}

		public List<Node> GetNeibourhood (Node node)
		{
				List<Node> neibourhood = new List<Node> ();
				for (int i=-1; i<=1; i++) {
						for (int j=-1; j<=1; j++) {
								if (i == 0 && j == 0) {
										continue;
								}
				
								int tempX = node._gridX + i;
								int tempY = node._gridY + j;
				
								if (tempX < gridCntX && tempX > 0 && tempY < gridCntY && tempY > 0) {
										neibourhood.Add (grid [tempX, tempY]);
								}
						}
				}
		
				return neibourhood;
		}

		// Update is called once per frame
		void Update ()
		{
	
		}
}
