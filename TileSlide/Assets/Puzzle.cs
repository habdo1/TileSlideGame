using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
	public Texture2D img;

	public int blocksPerLine;
	int shuffleAmt;

	Block emptyBlock;
	Block[,] blockMap;

	void initPuzzle()
	{
		blocksPerLine = GameData.GridSize;
		print ("Blocks per line: " + blocksPerLine);
		Texture2D[,] imgCut = ImgCut.getSlices (img, blocksPerLine);
		blockMap = new Block[blocksPerLine, blocksPerLine];
		shuffleAmt = blocksPerLine * blocksPerLine;

		for (int y = 0; y < blocksPerLine; y++)
		{
			for (int x = 0; x < blocksPerLine; x++)
			{
				GameObject blockObj = GameObject.CreatePrimitive (PrimitiveType.Quad);
				blockObj.transform.position = -Vector2.one * (blocksPerLine - 1) * .5f + new Vector2 (x, y);
				blockObj.transform.parent = transform;

				Block block = blockObj.AddComponent<Block> ();
				block.Init (new Vector2Int (x, y), imgCut [x, y]);
				block.onBlockPressed += moveBlockInput;
				blockMap [x, y] = block;

				if (y == 0 && x == blocksPerLine - 1)
				{
					blockObj.SetActive (false);
					emptyBlock = block;
				}
			}
		}
		shufflePuzzle ();

		Camera.main.orthographicSize = blocksPerLine * .6f;
	}

	// Use this for initialization
	void Start ()
	{
		initPuzzle ();
		print ("Initialized game");
	}

	void moveBlock(Block pressedBlock)
	{
		print ("pressed block");
		bool sameRow = false;
		bool sameCol = false;

		if (pressedBlock.xy.x == emptyBlock.xy.x)
			sameCol = true;
		if (pressedBlock.xy.y == emptyBlock.xy.y)
			sameRow = true;

		if (sameCol || sameRow)
		{
			if (sameRow)
			{
				if (pressedBlock.xy.x < emptyBlock.xy.x)
				{
					int xCurr = emptyBlock.xy.x - 1;
					int yCurr = emptyBlock.xy.y;
					while(xCurr >= pressedBlock.xy.x)
					{
						Block currBlock = blockMap [xCurr, yCurr];
						swapPositions (currBlock, emptyBlock);
						xCurr--;
					}
				}
				else
				if (pressedBlock.xy.x > emptyBlock.xy.x)
				{
					int xCurr = emptyBlock.xy.x + 1;
					int yCurr = emptyBlock.xy.y;
					while(xCurr <= pressedBlock.xy.x)
					{
						Block currBlock = blockMap [xCurr, yCurr];
						swapPositions (currBlock, emptyBlock);
						xCurr++;
					}
				}
			}

			if (sameCol)
			{
				if (pressedBlock.xy.y < emptyBlock.xy.y)
				{
					int xCurr = emptyBlock.xy.x;
					int yCurr = emptyBlock.xy.y - 1;
					while(yCurr >= pressedBlock.xy.y)
					{
						Block currBlock = blockMap [xCurr, yCurr];
						swapPositions (currBlock, emptyBlock);
						yCurr--;
					}
				}
				else
				if (pressedBlock.xy.y > emptyBlock.xy.y)
				{
					int xCurr = emptyBlock.xy.x;
					int yCurr = emptyBlock.xy.y + 1;
					while(yCurr <= pressedBlock.xy.y)
					{
						Block currBlock = blockMap [xCurr, yCurr];
						swapPositions (currBlock, emptyBlock);
						yCurr++;
					}
				}
			}
		}
	}

	void swapPositions (Block a, Block b)
	{
		blockMap [a.xy.x, a.xy.y] = b;
		blockMap [b.xy.x, b.xy.y] = a;

		Vector2Int targetxy = a.xy;
		a.xy = b.xy;
		b.xy = targetxy;
		Vector2 TmpPosition = a.transform.position;
		a.slideTo (b.transform.position, .1f);
		b.transform.position = TmpPosition;
	}

	void moveBlockInput(Block block)
	{
		print ("in moveblockinput");
		moveBlock (block);
	}

	void shuffleOnce(Block a, Block b)
	{
		blockMap [a.xy.x, a.xy.y] = b;
		blockMap [b.xy.x, b.xy.y] = a;

		Vector2Int targetxy = a.xy;
		a.xy = b.xy;
		b.xy = targetxy;
		Vector2 TmpPosition = a.transform.position;
		a.transform.position = b.transform.position;
		b.transform.position = TmpPosition;
	}

	void shufflePuzzle()
	{
		for (int i = 0; i < shuffleAmt; i++)
		{
			int rand = Random.Range (0, shuffleAmt);
			int row = rand / blocksPerLine;
			int col = rand % blocksPerLine;

			shuffleOnce (emptyBlock, blockMap[row, col]);
		}

		shuffleOnce(emptyBlock, blockMap[blocksPerLine - 1, 0]);
	}
}