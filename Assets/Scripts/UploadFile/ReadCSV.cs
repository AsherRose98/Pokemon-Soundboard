using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadCSV : MonoBehaviour {

	public TextAsset TextFile;
	[HideInInspector]
	public string[] TextFileText;

	void Start () {
		readData ();
	}

	void readData(){

		//Debug.Log ("File: "+TextFile);
		//Debug.Log ("Full Text: "+TextFile.text);

		string[] filelines = TextFile.text.Substring(1).Split('\n');
		foreach (string line in filelines) {
			TextFileText = line.Trim().Split(',');
			Global.PokemonList.Add(TextFileText);
		}
	}

}
