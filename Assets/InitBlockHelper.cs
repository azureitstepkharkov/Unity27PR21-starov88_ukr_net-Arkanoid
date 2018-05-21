using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitBlockHelper : MonoBehaviour {

    public GameObject block1;
    public GameObject block2;
    public GameObject block3;
    public GameObject block4;
    public GameObject block5;
    
    private static readonly float widthArea = 300f;
    private static readonly int maxBlocksPerLine = (int)(widthArea / Block.X);

    void Start ()
    {
        List<GameObject> prefabs = new List<GameObject> { block1, block2, block3, block4, block5 };
        int block_counter = 0;
        int numLines = SceneManager.GetActiveScene().buildIndex + 5;

        for (int line = 0; line < numLines; line++)
        {
            GameObject block = prefabs[Random.Range(0, 4)];
            foreach (var item in GetBlockLine(Random.Range(0, maxBlocksPerLine), 100 - line * Block.Y, Random.Range(0, 2)))
            {
                Instantiate(block, item, Quaternion.identity);
                block_counter++;
            }
            Thread.Sleep(11);
        }

        PlayerPrefs.SetInt("blocks_count", block_counter);
    }

    private List<Vector2> GetBlockLine(int sumBlocks, float posY, int addSpacing = 0)
    {
        List<Vector2> vectors = new List<Vector2>(sumBlocks);
        float spacing = 0;
        if (addSpacing != 0)
        {
            spacing = ((widthArea - (sumBlocks * Block.X)) / sumBlocks - 1);
            for (int i = 0; i < sumBlocks; i++)
            {
                vectors.Add(new Vector2(i * (Block.X + spacing) + spacing / 2 - 80, posY));
            }
        }
        else
        {
            spacing = ((widthArea - (sumBlocks * Block.X)) / 2);
            for (int i = 0; i < sumBlocks; i++)
            {
                vectors.Add(new Vector2(i * Block.X + spacing - 80, posY));
            }
        }

        return vectors;
    }
}
