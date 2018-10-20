using System.Collections;
using UnityEngine;
using System.IO;

public class SpawnButtons : MonoBehaviour {
	public GameObject ButtonPrefab;
	GameObject SoundsList;

	void Start () {
		SoundsList = GameObject.Find ("SoundsList");
		//ReadCSV reader = gameObject.AddComponent<ReadCSV> ();
		foreach(string[] item in Global.PokemonList){
			//Debug.Log (item.Length);
			spawnButton (item[0],item[1],item[2],item[3],item[4]);
		}
	}

	public void spawnButton(string id, string pokemonName, string type1, string type2, string gen){
			//Instantiate Button
		GameObject button = GameObject.Instantiate (ButtonPrefab,Vector3.zero, Quaternion.identity);
			//Set Parent
		button.transform.SetParent (SoundsList.transform, false);
			//SetData
		button.GetComponent<ButtonData> ().setData (id, pokemonName, type1, type2, gen);
	}

}
