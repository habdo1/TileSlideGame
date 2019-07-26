using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ImgCut {

	public static Texture2D[,] GetSlices(Texture2D img, int blocksPerLine)
	{
		int imgSize = Mathf.Min (img.width, img.height);
		int blockSize = imgSize / blocksPerLine;

		Texture2D[,] blocks = new Texture2D[blocksPerLine, blocksPerLine];

		for (int y = 0; y < blocksPerLine; y++)
		{
			for (int x = 0; x < blocksPerLine; x++)
			{
				Texture2D block = new Texture2D (blockSize, blockSize);
				block.SetPixels (img.GetPixels (x * blockSize, y * blockSize, blockSize, blockSize));
				block.Apply ();
				blocks [x, y] = block;
			}
		}

		return blocks;
	}
}
