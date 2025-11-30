using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedEffect;
    void OnParticleCollision(GameObject other)
    {
        Instantiate(destroyedEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
