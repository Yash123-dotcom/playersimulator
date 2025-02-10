using UnityEngine;
using UnityEngine.UI;

public class CameraSwitcher : MonoBehaviour
{
    public Camera thirdPersonCam;
    public Camera firstPersonCam;
    public Camera topDownCam;

    public Button thirdPersonButton;
    public Button firstPersonButton;
    public Button topDownButton;

    public Transform player; // Assign player transform in the Inspector
    public Vector3 thirdPersonOffset = new Vector3(0, 3, -5);
    public Vector3 firstPersonOffset = new Vector3(0, 1.6f, 0);
    public Vector3 topDownOffset = new Vector3(0, 10, -2);

    private Camera activeCamera;
    private Vector3 activeOffset;

    void Start()
    {
        // Assign Button Click Events
        thirdPersonButton.onClick.AddListener(SetThirdPerson);
        firstPersonButton.onClick.AddListener(SetFirstPerson);
        topDownButton.onClick.AddListener(SetTopDown);

        // Set Default Camera
        SetThirdPerson();
    }

    void LateUpdate()
    {
        if (activeCamera != null && player != null)
        {
            activeCamera.transform.position = player.position + activeOffset;
            activeCamera.transform.LookAt(player.position);
        }
    }

    void SetThirdPerson()
    {
        ActivateCamera(thirdPersonCam, thirdPersonOffset);
    }

    void SetFirstPerson()
    {
        ActivateCamera(firstPersonCam, firstPersonOffset);
    }

    void SetTopDown()
    {
        ActivateCamera(topDownCam, topDownOffset);
    }

    void ActivateCamera(Camera selectedCamera, Vector3 offset)
    {
        thirdPersonCam.gameObject.SetActive(false);
        firstPersonCam.gameObject.SetActive(false);
        topDownCam.gameObject.SetActive(false);

        selectedCamera.gameObject.SetActive(true);
        activeCamera = selectedCamera;
        activeOffset = offset;
    }
}
