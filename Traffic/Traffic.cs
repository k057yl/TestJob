using UnityEngine;

public class Traffic : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    Vector3 pos;
    
    private void Update()
    {
        pos = transform.position;
        if (pos.x < 0)
        {
            rb.AddForce(Vector3.right * 10f, ForceMode.Impulse);
        }
        else
        {
            rb.AddForce(-Vector3.right * 10f, ForceMode.Impulse);
        }
    }

}
