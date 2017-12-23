using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour {


	[SerializeField]//私人物件,但可出現在component
	private Slider healthSlider;
	private int currentHealth;

	[SerializeField]
	private float speed = 5f;



	//...........測試
	[ContextMenu("Test init 100")]
	private void TestInit()
	{
		Init (100);
	}

	[ContextMenu("Test hurt 50")]
	private void TestHurt()
	{
		Hurt (50);
	}


	public bool IsOver
	{
		get
		{
			return currentHealth<= healthSlider.minValue;
		}
	}

	public void Init(int maxHealth)
	{
		healthSlider.maxValue = maxHealth;
		healthSlider.value = maxHealth;
		currentHealth = maxHealth;
	}

	public void Hurt(int damage)
	{
		currentHealth -= damage;
		currentHealth = (int)Mathf.Max (currentHealth, healthSlider.minValue);
	}


	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	private void Update () 
	{
		healthSlider.value=Mathf.Lerp(healthSlider.value,currentHealth,Time.deltaTime*speed);
	}
}
