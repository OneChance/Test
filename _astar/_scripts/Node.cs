using UnityEngine;
using System.Collections;

public class Node {
	public bool _walkable;
	public Vector3 _pos;
	public int _x,_y;

	public int gCost; //与起点距离
	public int hCost; //与目标点距离

	public int fCost{
		get{return gCost+hCost;}
	}

	public Node parent;

	public Node (bool walkable,Vector3 pos,int x,int y){
		_walkable = walkable;
		_pos = pos;
		_x = x;
		_y = y;
	}
}
