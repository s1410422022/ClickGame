using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshFader : MonoBehaviour {

	//淡入淡出
	public Renderer[] fadeRenderers;
	public float speed = 1f;

	//測試
	[ContextMenu("Test FadeIn")]
	private void Test()
	{
		StartCoroutine (FadeIn());
	}

	[ContextMenu("Test2 FadeOut")]
	private void Test2()
	{
		StartCoroutine (FadeOut());
	}



	public IEnumerator FadeIn()
	{
		StopCoroutine (FadeOut());
		float alpha = 0;
		for (int i = 0; i < fadeRenderers.Length; i++)
		{
			Color color = fadeRenderers [i].material.color;
			color.a = alpha;
			fadeRenderers [i].material.color = color;
		}

		while (alpha < 1) 
		{
			alpha += Time.deltaTime * speed;
			alpha = Mathf.Min (1, alpha); //ALPHA1.1>>取最小值1>>變回1
			ChangeAlpha(alpha);
			yield return null;
		}
	}


	public IEnumerator FadeOut()
	{
		StopCoroutine (FadeIn());
		float alpha = 1;
		for (int i = 0; i < fadeRenderers.Length; i++)
		{
			Color color = fadeRenderers [i].material.color;
			color.a = alpha;
			fadeRenderers [i].material.color = color;
		}

		while (alpha > 0) 
		{
			alpha -= Time.deltaTime * speed;
			alpha = Mathf.Max (0, alpha); //ALPHA1.1>>取最小值1>>變回1
			ChangeAlpha(alpha);
			yield return null;
		}
	}



	private void ChangeAlpha(float alpha){
		for (int i = 0; i < fadeRenderers.Length; i++)
		{
			Color color = fadeRenderers [i].material.color;
			color.a = alpha;
			fadeRenderers [i].material.color = color;
		}
	}


}
