using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]//屬性>>要有它存在
[RequireComponent(typeof(MeshFader))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(HealthComponent))]

public class EnemyBehavior : MonoBehaviour {

	private Animator animator;
	private MeshFader meshFader; //腳本
	private AudioSource audioSource;
	private HealthComponent healthComponent; //腳本


	[SerializeField]
	public AudioClip hurtClip;
	[SerializeField]
	public AudioClip deadClip;

    private PlayerController playerController;

    public Transform hitPoint;

    public bool IsDead
	{
		get
		{ 
			return healthComponent.IsOver;
		}
	}



	private void Awake()
	{
		animator = GetComponent<Animator>();
		meshFader= GetComponent<MeshFader>();
		audioSource= GetComponent<AudioSource>();
		healthComponent= GetComponent<HealthComponent>();
        playerController = GameFacade.GetInstance().PlayerController;

	}



	private void OnEnable(){
		StartCoroutine (meshFader.FadeIn());//淡入
	}





	// Use this for initialization
	void Start () {
		
	}

	public IEnumerator Execute(EnemyData enemyData)
	{
		healthComponent.Init (enemyData.health);//初始化
		while(IsDead == false)//敵人是否已死亡
		{
			yield return null;
		}

		animator.SetTrigger("die");
		audioSource.clip = deadClip;
		audioSource.Play();

		yield return new WaitForSeconds (animator.GetCurrentAnimatorClipInfo (0).Length);//等待,動畫播放的時間長度

		yield return StartCoroutine (meshFader.FadeOut());//淡出
	
	}




	public void DoDamage(int attack)
	{
		animator.SetTrigger ("hurt");//撥放動畫
		audioSource.clip = hurtClip;
		audioSource.Play ();

		healthComponent.Hurt (attack);

	}

	// Update is called once per frame
	private void  Update () 
	{
		if (IsDead) 
		{
			return;
		}

#if UNITY_EDITOR
        if (Input.GetButtonDown ("Fire1")) //當滑鼠按下一次
		{
            playerController.OnClickEnemy(this);

        }
#else
        if (Input.touchCount > 0) {
            for (int i=0;i<Input.touchCount;i++) {
                if (Input.GetTouch(i).phase == TouchPhase.Began) {
                    playerController.OnClickEnemy(this);
                }
            }
        }

#endif
    }
}