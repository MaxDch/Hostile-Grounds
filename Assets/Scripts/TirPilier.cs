using UnityEngine;

public class TirPilier : MonoBehaviour
{
    public float Timer;
    public GameObject Projectile;
    public GameObject ZoneTir;
    Health _health = null;


    void Start()
    {
        Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void FixedUpdate()
    {
        Timer = Timer + Time.deltaTime;
        if (Timer > 2.0 && _health != null)
        {
            GameObject BouletPilier = Instantiate(Projectile, ZoneTir.transform.position, Quaternion.identity);
            BouletPilier.GetComponent<Projectile>().SetSpawner(gameObject);
            ZoneTir.transform.LookAt(_health.transform.position + Vector3.up * 1.5f);
            BouletPilier.GetComponent<Rigidbody>().AddForce(ZoneTir.transform.forward * 20.0f, ForceMode.Impulse);
            Timer = 0;

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _health = other.GetComponent<Health>();
            Timer = 0;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _health = null;
        }
    }


}
