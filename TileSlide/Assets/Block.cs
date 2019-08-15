using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	public event System.Action<Block> onBlockPressed;
	public Vector2Int xy;
	public Vector2Int initialXy;

	public void Init(Vector2Int startingxy, Texture2D img)
	{
		xy = startingxy;
		initialXy = startingxy;
		GetComponent<MeshRenderer> ().material.shader = Shader.Find("Unlit/Texture");
		GetComponent<MeshRenderer> ().material.mainTexture = img;
	}

	public void slideTo(Vector2 end, float time)
	{
		StartCoroutine (slide (end, time));
	}

	IEnumerator slide(Vector2 end, float time)
	{
		Vector2 start = transform.position;
		float progress = 0;

		while (progress < 1)
		{
			progress += Time.deltaTime / time;
			transform.position = Vector2.Lerp (start, end, progress);
			yield return null;
		}
	}

	void OnMouseDown()
	{
		if (onBlockPressed != null)
		{
			print ("In onMouseDown");
			onBlockPressed (this);
		}
	}

	public bool isAtStart()
	{
		return initialXy == xy;
	}
}
