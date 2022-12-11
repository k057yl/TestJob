using UnityEngine;

public class TargetPoint : MonoBehaviour
{
    [SerializeField] GameObject pizzaOpen;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            pizzaOpen.SetActive(true);
        }
    }
}
