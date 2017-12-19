using UnityEngine;

public class CameraController : MonoBehaviour {

    private bool doMovement = true;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;
    public float minX = 0f;
    public float maxX = 100f;
    public float minZ = 10f;
    public float maxZ = 165f;

    private void Update()
    {
        if (GameManager.gameEnded)
        {
            this.enabled = false;
            return;
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            doMovement = !doMovement;
        }
        if (!doMovement)
        {
            return;
        }
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime,Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);           
        }
        // use to zoom
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= scroll * 500 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}
