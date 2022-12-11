using System.Collections;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Vector3 offset;

    [SerializeField] Player pl;
    [SerializeField] GameObject playerSpawn;

    [SerializeField] Traffic tr;
    [SerializeField] GameObject[] carSpawn;

    [SerializeField] GameObject joy;
    [SerializeField] Transform canvas;

    GameObject player;
    GameObject traffic;
    GameObject joystick;

    float randomSpawn;
    float horizJoy;
    float verticJoy;

    private void Awake()
    {
        player = Instantiate(pl.gameObject, playerSpawn.transform.position, Quaternion.Euler(0f,90f,0f));
        joystick = Instantiate(joy, canvas.transform);
    }
    IEnumerator Wait()
    {
        SpawnTrafficR();
        yield return new WaitForSeconds(randomSpawn);
        SpawnTrafficL();
    }
    private void Update()
    {
        randomSpawn = Random.Range(0f, 3f);
        CameraFollow();
        if(traffic == null) 
        {
            StartCoroutine(Wait());
        }
        horizJoy = joystick.GetComponent<FixedJoystick>().Horizontal;
        verticJoy = joystick.GetComponent<FixedJoystick>().Vertical;
    }
    private void FixedUpdate()
    {
        player.GetComponent<Animator>().SetFloat("Run", Mathf.Abs(verticJoy));
        player.GetComponent<Rigidbody>().velocity = new Vector3(horizJoy * 10f, 0f, verticJoy * 10f);
    }
    void CameraFollow()
    {
        cam.transform.position = player.transform.position + offset;
    }
    void SpawnTrafficR()
    {
        traffic = Instantiate(tr.gameObject, carSpawn[0].transform.position, Quaternion.Euler(0f, -90f, 0f));
        Destroy(traffic, 3f);
    }
    void SpawnTrafficL()
    {
        traffic = Instantiate(tr.gameObject, carSpawn[1].transform.position, Quaternion.Euler(0f, 90f, 0f));
        Destroy(traffic, 3f);
    }
}
