using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    [SerializeField] internal Rigidbody rb;
    [SerializeField] internal Animator anim;
    [SerializeField] GameObject pizza;


    private void Start()
    {
        pizza.SetActive(false);
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Pizza")
        {
            pizza.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Target")
        {
            pizza.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Traffic")
        {
            anim.SetBool("Crush", true);
            Invoke("RestartLevel", 2f);
        }
    }
    void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
