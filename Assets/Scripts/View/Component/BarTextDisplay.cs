using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class BarTextDisplay : MonoBehaviour {
	 
	private Slider slider;

	[SerializeField]
	private Text label;

	// Use this for initialization
	private void Awake () {

		slider = GetComponent<Slider>();
		slider.onValueChanged.AddListener(OnValueChanged);//通知
	}


	private void OnValueChanged(float val)
	{
		val = Mathf.FloorToInt (val);//無條件捨棄小數點後位>>為整數
		label.text= val+"/"+slider.maxValue;
		
	}



	// Update is called once per frame
	void Update () {
		
	}
}
