using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour
{
    public GUIText finalScore;
    public GUIText deadText;

    // Use this for initialization
    void Start()
    {
        finalScore.text = GameController.TreeInstance.Score.ToString();
        deadText.text = GameController.TreeInstance.DeadCause;
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2, 80, 50), "Retry?"))
        {
            GameController.TreeInstance.NavigateGameScreen();
        }
    }

    void Update()
    {
        GameController.TreeInstance.GenericInputListener();
    }

}
