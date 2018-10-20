using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonData : MonoBehaviour {

	public string Id;
	public string Name;
	public string Type1;
	public string Type2;
	public string Gen;


	public void setData(string id, string name, string type1, string type2, string gen){
		Id = id;
		Name = name;
		Type1 = type1;
		Type2 = type2;
		Gen = gen;

	//Set Editor Name
		gameObject.name = name;
	//Set Button Text
		GetComponentInChildren<Text> ().text = name;
	//Set Audio File
		//Debug.Log(id.Remove(0,1));
		GetComponent<AudioSource>().clip = Resources.Load (id.Remove(0,1)) as AudioClip;
	//Set Button OnClick Function
		gameObject.GetComponent<Button> ().onClick.AddListener(() => PlaySound());
	}

	void PlaySound(){
		GetComponent<AudioSource> ().Play ();
	}
}
	
