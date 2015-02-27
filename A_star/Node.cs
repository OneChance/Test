using UnityEngine;
using System.Collections;

public class Node
{
		public bool _canWalk;
		public Vector3	_worldPos;
		public int _gridX, _gridY;
		public int gCost;
		public int hCost;

		public int fCost {
				get{ return gCost + hCost;}
		}

		public Node parent;

		public Node (bool CanWalk, Vector3 Position, int x, int y)
		{
				_canWalk = CanWalk;
				_worldPos = Position;
				_gridX = x;
				_gridY = y;
		}

}
