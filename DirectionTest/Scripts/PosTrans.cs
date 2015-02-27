using UnityEngine;
using System.Collections;

public class PosTrans : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetMouseButtonDown (0)) {
						Vector3 m_pos = Input.mousePosition;
						
						Vector3 stw = Camera.main.ScreenToWorldPoint (m_pos);
						Vector3 spr = new Vector3 (999, 999, 999);
						Ray r = Camera.main.ScreenPointToRay (m_pos);
						RaycastHit hit;
						if (Physics.Raycast (r, out hit)) {
								spr = hit.point;
						}
				
						Debug.Log (stw);
						Debug.Log (spr);
				}
		}
}
