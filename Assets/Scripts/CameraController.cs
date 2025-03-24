using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Range(50,500)]
    [SerializeField] float sensivity;
    [SerializeField] Transform player;
    [SerializeField] float xRot = 0.0f;
    [SerializeField] float smoothing;
    float currentRot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotX = Input.GetAxisRaw("Mouse X") * sensivity * Time.deltaTime;
        float rotY = Input.GetAxisRaw("Mouse Y") * sensivity * Time.deltaTime;

        xRot -= rotY;
        xRot = Mathf.Clamp(xRot, -80f, 80f);

        currentRot += rotX;
        xRot = Mathf.Lerp(currentRot, 0, Time.deltaTime * smoothing);

        transform.localRotation = Quaternion.Euler(xRot, 0f, currentRot);
        player.Rotate(Vector3.up * rotX);
    }
}
