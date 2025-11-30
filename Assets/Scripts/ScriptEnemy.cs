using UnityEngine;

public class ScriptEnemy : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        Destroy(this.gameObject);
    }
}
