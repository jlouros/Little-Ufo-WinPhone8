using UnityEngine;

public class ScoreUpdateScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.guiText.text = GameController.TreeInstance.Score.ToString();
    }
}
