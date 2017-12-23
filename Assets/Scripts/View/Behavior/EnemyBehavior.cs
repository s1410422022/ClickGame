using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]//屬性>>要有它存在

public class EnemyBehavior : MonoBehaviour {

	private Animator animator;

	private void Awake()
	{
		animator = GetComponent<Animator>();

	}





	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
