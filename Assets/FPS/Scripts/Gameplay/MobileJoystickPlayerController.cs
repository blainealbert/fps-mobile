using UnityEngine;

public class MobileJoystickPlayerController : MonoBehaviour
{
    public GameObject joystick;
    public float horizontalInput = 0;
    public float verticalInput = 0;

    private void Start()
    {

    }

    private void Update()
    {
        horizontalInput = 0;
        verticalInput = 0;

        // Get the joystick input, if no input then check for key input
        if(joystick.GetComponent<MobileJoystick>().Horizontal != 0 && joystick.GetComponent<MobileJoystick>().Vertical != 0) {
            horizontalInput = joystick.GetComponent<MobileJoystick>().Horizontal;
            verticalInput = joystick.GetComponent<MobileJoystick>().Vertical;

        } 
    }
}