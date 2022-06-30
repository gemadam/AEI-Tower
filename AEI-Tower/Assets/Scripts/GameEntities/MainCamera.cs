using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public bool EnableMovement = false;

    public float CameraSpeed = 0.01f;
    public Vector3 InitialPosition = new Vector3(0f, 0f, -20f);

    // Update is called once per frame
    void Update()
    {
        if (Camera.current != null && EnableMovement)
        {
            Camera.current.transform.Translate(new Vector3(0f, CameraSpeed * Time.deltaTime, 0f));
        }
    }

    public void ResetState()
    {
        if (Camera.main == null)
            return;

        Camera.main.transform.position = InitialPosition;
        CameraSpeed = 1;
    }
}
