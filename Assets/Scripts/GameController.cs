using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //Platform gameobject
    [Header("Platform Object")] public GameObject platform;
    //Default position for platform
    float pos = 0;
    //Game over Canvas
    [Header("Game OVer UI Canvas Object")]
    public GameObject gameOverCanvas;
    [Header("position")]
    public float position;

    // Start is called before the first frame update
    void Start()
    {
        //Integer i equals 1000
        for (int i = 0; i < 1000; i++)
        {
            //Execute SpawnPlatforms
            SpawnPlatforms();
        }
    }

    //Spawn platforms functions
    void SpawnPlatforms()
    {
        //Spawn platforms randomly on the X axis and place them on the Y axis every 2.5
        Instantiate(platform, new Vector3(Random.value * 10 - 5f, pos, 0.5f), Quaternion.identity);
        pos += 2.5f;
        pos += position;
    }

    public void GameOver()
    {
        //Game Over Canvas is active
        gameOverCanvas.SetActive(true);
    }
}