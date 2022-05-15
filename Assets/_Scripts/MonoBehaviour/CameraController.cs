using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 20f;
    public float rotationSpeed = 3.5f;
    public float scrollSpeed = 20f;
    public float scrollEdge = 0.01f;
    public Vector2 panLimit;
    public float minY = 20f;
    public float maxY = 120f;

    private Vector3 initialRotation;
    // Start is called before the first frame update
    void Start()
    {
        initialRotation = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height * (1 - scrollEdge))
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= Screen.height * scrollEdge)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width * (1 - scrollEdge))
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= Screen.width * scrollEdge)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);
        transform.position = pos;
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * rotationSpeed, -Input.GetAxis("Mouse X") * rotationSpeed, 0));
            var X = transform.rotation.eulerAngles.x;
            var Y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(X, 0, 0);
        }

    }
}
