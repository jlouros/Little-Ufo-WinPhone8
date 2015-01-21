using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour
{
    public AudioClip explosionSFX;

    private Vector3 defaultPlayPosition = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start()
    {
        AudioSource.PlayClipAtPoint(explosionSFX, defaultPlayPosition);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ExplosionDoneEvent()
    {
        Destroy(this.gameObject);
        GameController.TreeInstance.NavigateGameOverScreen();
    }

}