using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] Text coinText;
    [SerializeField] Text hpText;

    GameObject player;
    GameObject traffic;
    GameObject joystick;

    public float speed;

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
        CameraFollow();
        randomSpawn = Random.Range(0f, 1.5f);
        
        if(traffic == null) 
        {
            StartCoroutine(Wait());
        }
        horizJoy = joystick.GetComponent<FixedJoystick>().Horizontal;
        verticJoy = joystick.GetComponent<FixedJoystick>().Vertical;

        coinText.text = player.GetComponent<Player>().coin.ToString();
        hpText.text = player.GetComponent<Player>().hp.ToString();
    }
    private void FixedUpdate()
    {
        player.GetComponent<Animator>().SetFloat("Run", Mathf.Abs(verticJoy));
        player.GetComponent<Rigidbody>().AddForce(new Vector3(horizJoy * speed, 0f, verticJoy * speed));
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
