using UnityEngine;

public class MainMenuScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2, 80, 50), "New Game"))
        {
            GameController.TreeInstance.NavigateGameScreen();
        }
    }

    void Update()
    {
        GameController.TreeInstance.GenericInputListener();
    }
}
