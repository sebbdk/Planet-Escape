using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Message : MonoBehaviour {

	public float lastMessageShow;
	public float duration;

	public static void text (string text, float duration = 3) {
		GameObject message = GameObject.FindGameObjectWithTag("Message");
		message.GetComponent<Text>().text = text;
		message.GetComponent<Message>().duration = duration;
		message.GetComponent<Message>().lastMessageShow = Time.time;
	}


	void Update() {
		if(Time.time - lastMessageShow > lastMessageShow+duration) {
			GetComponent<Text>().text = "";
		}
	}
}
