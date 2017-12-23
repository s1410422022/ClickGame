using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

		return instance;
	}

	public StageData[] stageData;

}
