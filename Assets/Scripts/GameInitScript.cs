using UnityEngine;
using System.Collections;

public class GameInitScript : MonoBehaviour
{
    public GameObject player;
    public GUIText scoreDisplay;
    public GameObject asteroid1;

    private float minX = 3.2f;
    private float maxX = 4.2f;
    private float minY = 1f;
    private float maxY = 4.5f;

    // Use this for initialization
    void Start()
    {
        Instantiate(player);

        Invoke("MakeAsteroid", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = GameController.TreeInstance.Score.ToString();

        GameController.TreeInstance.GenericInputListener();
    }


    Vector3 GetRandomPosition(bool topElem)
    {
        float randX = Random.Range(minX, maxX);
        float randY = Random.Range(minY, maxY);

        if (!topElem)
        {
            randY = randY * -1;
        }

        return new Vector3(randX, randY);
    }

    void MakeAsteroid()
    {
        Instantiate(asteroid1, GetRandomPosition(true), Quaternion.identity);

        Instantiate(asteroid1, GetRandomPosition(false), Quaternion.identity);

        Invoke("MakeAsteroid", Random.Range(1.0f, 2.0f));
    }
}
