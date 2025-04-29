using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private Transform mainCamera;

    private void Start()
    {
        if (Camera.main != null)
        {
            mainCamera = Camera.main.transform;
        }
    }

    private void Update()
    {
        if (mainCamera != null)
        {
            // Get direction to camera on horizontal plane
            Vector3 lookDir = mainCamera.position - transform.position;
            lookDir.y = 0f; // keep only horizontal direction

            if (lookDir.sqrMagnitude > 0.001f)
            {
                Quaternion lookRotation = Quaternion.LookRotation(lookDir);

                // Combine your original rotation (e.g., -90 X) with Y-axis alignment
                transform.rotation = Quaternion.Euler(
                    transform.rotation.eulerAngles.x,
                    lookRotation.eulerAngles.y,
                    transform.rotation.eulerAngles.z
                );
            }
        }
    }
}
