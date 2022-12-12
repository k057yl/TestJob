using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetPoint : MonoBehaviour
{
    [SerializeField] GameObject can;
    [SerializeField] GameObject pizzaOpen;
    [SerializeField] ParticleSystem win;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject.GetComponent<Collider>());
            GetComponent<Animator>().enabled= false;
            win.Play();
            pizzaOpen.SetActive(true);
            can.SetActive(true);
        }
    }
}
