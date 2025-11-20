using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 50f;
    [SerializeField] float xClampRange = 20f;
    [SerializeField] float yClampRange = 20f;

    Vector2 movement;

    void Start()
    {

    }

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }


    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();

    }
    
    private void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float xClampedPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);

        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float yClampedPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(xClampedPos, yClampedPos , 0f);
    }

    private void ProcessRotation()
    {
        transform.localRotation = Quaternion.Euler(0f,0f,45f);
    }
}
