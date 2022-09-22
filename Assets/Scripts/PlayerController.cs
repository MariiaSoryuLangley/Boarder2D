using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 2f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] CustomButton leftButton;
    [SerializeField] CustomButton rightButton;
    Rigidbody2D rb2d;
    SurfaceEffector2D sf2d;
    bool controllsDisabled = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sf2d = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!controllsDisabled)
        {
            Rotate();
            RespondToBoost();
        }
    }

    public void DisableControlls()
    {
        controllsDisabled = true;
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            sf2d.speed = boostSpeed;
        }
        else
        {
            sf2d.speed = baseSpeed;
        }
    }

    public void Rotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || leftButton.IfButtonIsDown())
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || rightButton.IfButtonIsDown())
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
