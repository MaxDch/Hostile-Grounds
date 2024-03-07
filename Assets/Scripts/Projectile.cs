using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float _damageOnImpact = 10;
    public bool _shouldDieOnAnyImpact = false;
    private GameObject _spawner = null;

    public void SetSpawner(GameObject spawner)
    {
        _spawner = spawner; 
    }

    private bool HasHitSpawner(GameObject hittedObject)
    {
        if (hittedObject == _spawner)
        {
            return true;
        }

        if(hittedObject.transform.parent != null)
        {
            return HasHitSpawner(hittedObject.transform.parent.gameObject);
        }

        return false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.isTrigger)
        {
            return;
        }
        if (HasHitSpawner(collision.gameObject))
        {
            return;
        }

        Health health = collision.GetComponent<Collider>().gameObject.GetComponentInParent<Health>();
        if (health != null)
        {
            health.Damage(_damageOnImpact);
            Destroy(gameObject);
        }

        if(_shouldDieOnAnyImpact)
        {
            Destroy(gameObject);
        }
    }
}
