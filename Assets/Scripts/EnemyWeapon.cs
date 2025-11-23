using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] InputAction attackKey;
    [SerializeField] GameObject laser;

    void OnEnable()
    {
        attackKey.Enable();
    }

    void Start()
    {
        
    }

    void Update()
    {
        ProcessShooting();
    }

    void ProcessShooting()
    {
        bool isFiring = attackKey.IsPressed();

        var emissionShoot = laser.GetComponent<ParticleSystem>().emission;
        emissionShoot.enabled = isFiring;
    }
}
