using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckboxData : MonoBehaviour {
	
	public string Name;

	public void setData(string checkname){
		Name = checkname;

		gameObject.name = checkname + " Checkbox ";
		gameObject.GetComponentInChildren<Text> ().text = checkname;
	}

}
