using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float CameraSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.current != null)
        {
            Camera.current.transform.Translate(new Vector3(0f, CameraSpeed, 0f));
        }
    }
}
