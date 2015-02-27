using UnityEngine;
using System.Collections;
using System.Net;
using System.IO;
using System;

public class HttpRequest : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create ("http://www.baidu.com");
				System.Net.WebProxy proxy = new WebProxy ("49.74.85.139", 80);
				request.Proxy = proxy;
				using (WebResponse response = request.GetResponse()) {
						using (TextReader reader = new StreamReader(response.GetResponseStream())) {
								string line;
								while ((line = reader.ReadLine()) != null)
										Debug.Log (line);
						}
				}
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
