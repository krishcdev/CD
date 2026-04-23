using UnityEngine;

public class RotatingCylinder : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public Vector3 rotationAxis = Vector3.right; // change if needed

    void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}