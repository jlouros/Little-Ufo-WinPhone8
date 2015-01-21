using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public int speed;
    public GameObject explosion;
    public AudioClip jumpSFX;
    public GameObject asteroid;

    // Use this for initialization
    void Start()
    {
        this.rigidbody2D.AddForce(Vector2.up * speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                Jump();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    void Jump()
    {
        Vector2 velocityDown = this.rigidbody2D.velocity * -1;
        Vector2 forceToAdd = Vector2.up * speed;

        forceToAdd.y += (velocityDown.y * (speed / 10));

        this.rigidbody2D.AddForce(forceToAdd);

        AudioSource.PlayClipAtPoint(jumpSFX, new Vector3(0, 0, 0));
    }

    void OnCollisionEnter2D(Collision2D theCollision)
    {
        GameController.TreeInstance.PlayerDestroyed = true;

        switch (theCollision.gameObject.tag)
        {
            case "Orbit":
                GameController.TreeInstance.DeadCause = "swallowed by a black hole";
                ShipSwallow();
                break;
            case "asteriod":
            default:
                GameController.TreeInstance.DeadCause = "unfortunate encounter with a meteor";
                ShipCrash();
                break;
        }
    }

    void ShipCrash()
    {
        Vector3 pos = this.gameObject.transform.position;
        Destroy(this.gameObject);
        Instantiate(explosion, pos, Quaternion.identity);
    }

    void ShipSwallow()
    {
        //FIX
        ShipCrash();
    }

}