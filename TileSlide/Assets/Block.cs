using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	public event System.Action<Block> onBlockPressed;
	public Vector2Int xy;

	public void Init(Vector2Int startingxy, Texture2D img)
	{
		xy = startingxy;
		GetComponent<MeshRenderer> ().material.mainTexture = img;
	}

	public void slideTo(Vector2 end, float time)
	{
		StartCoroutine (Slide (end, time));
	}

	IEnumerator Slide(Vector2 end, float time)
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
			onBlockPressed (this);
		}
	}
}
