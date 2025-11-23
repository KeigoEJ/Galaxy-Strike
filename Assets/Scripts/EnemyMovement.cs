using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] float xClampedRange = 30f;
    [SerializeField] float yClampedRange = 30f;
    [SerializeField] float speedMovement = 10f;
    [SerializeField] float speedRotation = 20f;
    [SerializeField] float pitchRotationValue = 20f;
    [SerializeField] float rollRotationValue = 20f;

    Vector2 movementDirection;

    void OnEnable()
    {
        movement.Enable();
    }

    void Update()
    {
        ProcessMovement();
        ProcessRotation();
    }

    private void ProcessMovement()
    {
        movementDirection = movement.ReadValue<Vector2>();

        float xOffset = movementDirection.x * speedMovement * Time.deltaTime;
        float rawXoffset = xOffset + transform.localPosition.x;
        float xClampedpos = Mathf.Clamp(rawXoffset, -xClampedRange, xClampedRange);

        float yOffset = movementDirection.y * speedMovement * Time.deltaTime;
        float rawYOffset = transform.localPosition.y + yOffset;
        float yClampedpos = Mathf.Clamp(rawYOffset, -yClampedRange, yClampedRange);

        transform.localPosition = new Vector3(xClampedpos, yClampedpos, 0f);
    }

    private void ProcessRotation()
    {
        float pitch = movementDirection.y * -pitchRotationValue;
        float roll = movementDirection.x * -rollRotationValue;

        Quaternion rotationTarget = Quaternion.Euler(pitch, 0f, roll);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, rotationTarget, speedRotation * Time.deltaTime);
    }
}
