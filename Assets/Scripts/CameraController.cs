using UnityEngine;

public class FpsCameraController : MonoBehaviour
{
    [Header("Sensitivity")]
    [Range(50, 500)]
    [SerializeField] float mouseSensitivity = 100f;

    [Header("Joystick (Mobil)")]
    [SerializeField] Joystick lookJoystick;  // Joystick veya SimpleJoystick

    [Header("Transforms")]
    [SerializeField] Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        #if UNITY_STANDALONE || UNITY_EDITOR
        // Sadece PC platformu için fareyi kilitle
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible   = false;
        #endif
    }

    void Update()
    {
        float mouseX, mouseY;

        // Eğer Joystick nesnesi referans olarak atandıysa ve mobil platformdaysa
        if (lookJoystick != null && (Application.isMobilePlatform))
        {
            // Joystick verisi
            mouseX = lookJoystick.Horizontal * mouseSensitivity * Time.deltaTime;
            mouseY = lookJoystick.Vertical   * mouseSensitivity * Time.deltaTime;
        }
        else
        {
            // PC'de fare
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        }

        // Dikey rota
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
