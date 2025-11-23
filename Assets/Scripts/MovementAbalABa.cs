using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementAbalABa : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float xPositionOffset = 30f;
    [SerializeField] float yPositionOffset = 10f;
    Vector2 movement;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
    }

    public void OnMove(InputValue inputValue)
    {
        movement = inputValue.Get<float2>();
    }

    void ProcessMovement()
    {
        float xOffset = movement.x * speed * Time.deltaTime;
        float rawXPos = transform.localRotation.x + xOffset;
        float xClampedPos = Mathf.Clamp(rawXPos, -xPositionOffset, xPositionOffset);

        float yOffset = movement.y * speed * Time.deltaTime;
        float rawYPos = transform.rotation.y + yOffset;
        float yClampedPos = Mathf.Clamp(rawYPos, -yPositionOffset, yPositionOffset);

        transform.localPosition = new Vector2(xClampedPos, yClampedPos);
    }
}
