using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxSpeed;
    private Transform cam;
    private Vector3 previousCamPos;

    private void Start()
    {
        cam = Camera.main.transform;
        previousCamPos = cam.position;
    }

    private void Update()
    {
        Vector3 deltaMovement = cam.position - previousCamPos;
        transform.position += new Vector3(deltaMovement.x * parallaxSpeed, 0, 0);
        previousCamPos = cam.position;
    }
}
