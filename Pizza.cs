using UnityEngine;

public class Pizza : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.tag = "Player";
        Destroy(gameObject, 1f);
    }
}
