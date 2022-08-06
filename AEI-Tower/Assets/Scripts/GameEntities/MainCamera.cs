using UnityEngine;

/** 
 * Main camera class
 */
public class MainCamera : MonoBehaviour
{
    public bool EnableMovement = false;                             /*!< Enables movement of the camera */

    public float CameraSpeed = 0.01f;                               /*!< Speed of the camera */
    public Vector3 InitialPosition = new Vector3(0f, 0f, -20f);     /*!< Initial position of the camera */

    void Update()
    {
        if (Camera.current != null && EnableMovement)
        {
            Camera.current.transform.Translate(new Vector3(0f, CameraSpeed * Time.deltaTime, 0f));
        }
    }

    public void Reset()
    {
        CameraSpeed = 1;

        if (Camera.main == null)
            return;

        Camera.main.transform.position = InitialPosition;
    }
}
