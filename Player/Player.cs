using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    [SerializeField] internal Rigidbody rb;
    [SerializeField] internal Animator anim;
    [SerializeField] GameObject pizza;
    [SerializeField] AudioSource[] id;

    internal int coin;
    internal int hp = 1;

    private void Start()
    {
        pizza.SetActive(false);       
    }  

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Target")
        {
            id[2].Play();
            pizza.SetActive(false);
        }
        if (other.tag == "Pizza")
        {
            id[1].Play();
            pizza.SetActive(true);
            coin++;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Traffic")
        {
            id[0].Play();
            anim.SetBool("Crush", true);
            Invoke("GameOver", 1.8f);
            hp--;
        }

    }
    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
