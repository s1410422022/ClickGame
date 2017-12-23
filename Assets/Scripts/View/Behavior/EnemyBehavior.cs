using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]//屬性>>要有它存在
[RequireComponent(typeof(MeshFader))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(HealthComponent))]

public class EnemyBehavior : MonoBehaviour {

	private Animator animator;
	private MeshFader meshFader;
	private AudioSource audioSource;
	private HealthComponent healthComponent;

	public AudioClip hurtClip;

	private void Awake()
	{
		animator = GetComponent<Animator>();
		meshFader= GetComponent<MeshFader>();
		audioSource= GetComponent<AudioSource>();
		healthComponent= GetComponent<HealthComponent>();
	}



	private void OnEnable(){
		StartCoroutine (meshFader.FadeIn());
		healthComponent.Init (100);
	}





	// Use this for initialization
	void Start () {
		
	}


	public void DoDamage(int attack)
	{
		animator.SetTrigger ("hurt");
		audioSource.clip = hurtClip;
		audioSource.Play ();
		healthComponent.Hurt (attack);

	}

	// Update is called once per frame
	void Update () 
	{
		if (healthComponent.IsOver) 
		{
			return;
		}

		if (Input.GetButtonDown ("Fire1")) 
		{
			DoDamage (10);
		}
	}
}
