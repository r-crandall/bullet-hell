using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRigidbody;
    public float speed = 10f; //rename to playerSpeed?

    private Quaternion targetRotation;

    public Camera cam;
    public Transform movementRef;

    public float rotationSpeed = 450;

    public float printTimer = 5.0f;
    private float timer;

    public float ratioBetweenPlayerAndCam = 0.5f;
    
    private Vector3 finalCamPosition;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        timer = printTimer;
    }

    private void FixedUpdate()
    {
        MovePlayer();
        FaceMouse();
        timer -= Time.deltaTime;
        PositionPrinter();
    }

    void PositionPrinter()
    {
        if(timer <= 0)
        {
            Vector3 playerPos = playerRigidbody.position;
            Vector3 mousePos = Input.mousePosition;
                        
            Vector3 diff = playerPos - mousePos;
            finalCamPosition = playerPos + (diff * ratioBetweenPlayerAndCam);

            print("PlayePos: " + playerPos.ToString());
            print("MousePos: " + mousePos.ToString());
            print("finalCamPos: " + finalCamPosition.ToString());

            timer = printTimer;
        }
    }

    void MovePlayer()
    {
        //calculate movement velocity as a 3d vector. 
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = movementRef.right * _xMov;
        Vector3 _movVertical = movementRef.forward * _zMov;

        Vector3 velocity = (_movHorizontal + _movVertical).normalized * speed;
        playerRigidbody.velocity = velocity;
    }

    void FaceMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.transform.position.y - transform.position.y));
        targetRotation = Quaternion.LookRotation(mousePos - new Vector3(transform.position.x, 0, transform.position.z));
        transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
    }
}