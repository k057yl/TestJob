using UnityEngine;

public class Traffic : MonoBehaviour
{
    Vector3 pos;
    private void Update()
    {
        pos = transform.position;
        if(pos.x < 0)
        {
            GetComponent<Rigidbody>().AddForce(190f, 0f, 0f);
        }
        else
        {
            GetComponent<Rigidbody>().AddForce(-190f, 0f, 0f);
        }

    }
}
