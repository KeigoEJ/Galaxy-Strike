using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject playerDestroyed;
    [SerializeField] GameObject player3D;
    int currentScene;
    MeshRenderer meshy;
    CollisionHandler collisionScript;
    bool isPlayingEffect = true;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        meshy = player3D.GetComponent<MeshRenderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(isPlayingEffect)
        {
            Instantiate(playerDestroyed, transform.position, Quaternion.identity);
            meshy.enabled = false;
            this.enabled = false;
            isPlayingEffect = false;    
            Invoke("ReloadScene", 2f);
            
        }
    }

    void ReloadScene()
    {       
        SceneManager.LoadScene(currentScene);
    }
}
