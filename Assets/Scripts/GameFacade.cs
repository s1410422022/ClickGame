using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyController))]
[RequireComponent(typeof(GameStateController))]
[RequireComponent(typeof(PlayerController))]



public class GameFacade : MonoBehaviour 
{
	private static GameFacade instance;
	public static GameFacade GetInstance()
	{
		instance = GameObject.FindObjectOfType<GameFacade> ();

		if (instance == null) 
		{
			throw new System.Exception ("GameFacade不存在場景中,請在場景添加");
		}
        instance.Initialize();

		return instance;
	}

    public EnemyController EnemyController { private set; get; }
    public GameStateController GameStateController { private set; get; }
    public PlayerController PlayerController { private set; get; }

    public StageData[] stageDatas;
    public LevelData levelData;
    public PlayerData playerData;
    public GameStateData gameStateData;


    private void Initialize()
    {
        EnemyController = GetComponent<EnemyController>();
        GameStateController = GetComponent<GameStateController>();
        PlayerController = GetComponent<PlayerController>();
        playerData = new PlayerData();
        gameStateData = new GameStateData();

    }

    private void Awake()
    {
        GetInstance();
    }

}
