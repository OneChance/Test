using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class FindPath : MonoBehaviour
{

		private Grid _grid;
		public Transform _player, _target;

		// Use this for initialization
		void Start ()
		{
				_grid = GetComponent<Grid> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				FindingPath (_player.position,_target.position);
		}

		void FindingPath (Vector3 StartPos, Vector3 EndPos)
		{
				Node startNode = _grid.GetFromPosition (StartPos);
				Node endNode = _grid.GetFromPosition (EndPos);

				List<Node> openSet = new List<Node> ();
				HashSet<Node> closeSet = new HashSet<Node> ();

				openSet.Add (startNode);

				while (openSet.Count>0) {
						Node currentNode = openSet [0];

						for (int i=0; i<openSet.Count; i++) {
								if (openSet [i].fCost < currentNode.fCost || (openSet [i].fCost == currentNode.fCost && openSet [i].hCost < currentNode.hCost)) {
										currentNode = openSet [i];
								}
						}
				
						openSet.Remove (currentNode);
						closeSet.Add (currentNode);

						if (currentNode == endNode) {
								GeneratePath (startNode, endNode);
						}

						foreach (Node node in _grid.GetNeibourhood(currentNode)) {
								if (!node._canWalk || closeSet.Contains (node))
										continue;

								int newCost = currentNode.gCost + GetDistanceNodes (currentNode, node);
								if (newCost < node.gCost || !openSet.Contains (node)) {
										node.gCost = newCost;
										node.hCost = GetDistanceNodes (node, endNode);
										node.parent = currentNode;
										if (!openSet.Contains (node)) {
												openSet.Add (node);
										}
								}
						}
				}
		}

		int GetDistanceNodes (Node a, Node b)
		{
				int cntX = Mathf.Abs (a._gridX - b._gridX);
				int cntY = Mathf.Abs (a._gridY - b._gridY);

				if (cntX > cntY) {
						return 14 * cntY + 10 * (cntX - cntY);
				} else {
						return 14 * cntX + 10 * (cntY - cntX);
				}
		}

		void GeneratePath (Node startNode, Node endNode)
		{
				List<Node> path = new List<Node> ();
				Node temp = endNode;
				while (temp!=startNode) {
						path.Add (temp);
						temp = temp.parent;
				}
				path.Reverse ();
				_grid.path = path;
		}

}
