using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gamePanel, cube;
    int[] minePositionList = new int[10];
    void Awake()
    {
        CreateMineList();
    }
    void Start()
    {
        CreateCubes();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateCubes()
    {
        for (int i = 0; i < 81; i++)
        {
            GameObject cloneCube = Instantiate(cube, gamePanel.transform);
            if (minePositionList.Contains(i))
            {
                cloneCube.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "9";
            }
        }
    }
    
    void CreateMineList()
    {
        for (int i = 0; i < 10; i++)
        {
            int bomb = Random.Range(0, 81);
            while (minePositionList.Contains(bomb))
            {
                bomb = Random.Range(0, 81);
            }
            minePositionList[i] = bomb;
        }
    }

}
