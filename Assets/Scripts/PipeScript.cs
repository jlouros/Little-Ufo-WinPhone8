using UnityEngine;

public class PipeScript : MonoBehaviour
{
    private bool scoreGiven = false;
    private float movementSpeed = 2f;
    private float assignScorePos = -1.5f;
    private float destroyPos = -3.2f;

    // Use this for initialization
    void Start()
    {
        this.rigidbody2D.velocity = (-Vector2.right * movementSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x <= assignScorePos && !scoreGiven && !GameController.TreeInstance.PlayerDestroyed)
        {
            GameController.TreeInstance.Score++;

            scoreGiven = true;
        }

        if (this.transform.position.x <= destroyPos)
        {
            Destroy(this.gameObject);
        }
    }
}
