using UnityEngine;

public class TirPilier : MonoBehaviour
{
    public float Timer;
    public GameObject Projectile;
    public GameObject ZoneTir;
    GameObject Player;
    bool IsPlayerInRange;


    void Start()
    {
        Timer = 0;
        foreach (var charController in FindObjectsOfType<CharacterController>())
        {
            if (charController.gameObject.CompareTag("Player"))
            {
                Player = charController.gameObject;
                break;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void FixedUpdate()
    {
        Timer = Timer + Time.deltaTime;
        if (Timer > 2.0 && IsPlayerInRange)
        {
            GameObject BouletPilier = Instantiate(Projectile, ZoneTir.transform.position, Quaternion.identity);
            ZoneTir.transform.LookAt(Player.transform.position + Vector3.up * 1.5f);
            BouletPilier.GetComponent<Rigidbody>().AddForce(ZoneTir.transform.forward * 20.0f, ForceMode.Impulse);
            Timer = 0;

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            IsPlayerInRange = true;
            Timer = 0;

            print("le joueur entre dans la zone");


        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            IsPlayerInRange = false;




        }
    }


}
