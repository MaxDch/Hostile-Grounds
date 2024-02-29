using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTriggerDetector : MonoBehaviour
{
    float DistanceBetweenPlayer = 5.0f;
    public Transform BouclierBoss;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile") && other.TryGetComponent<Ctrl_Boulet_Pilier>(out var projectile))
        {
            gamemanager.Health = gamemanager.Health - 10;
            GameObject.Find("ValeurHealth").GetComponent<Text>().text = gamemanager.Health.ToString();
            projectile.Explode();
        }
        if (other.CompareTag("Lava"))
        {
            gamemanager.Health = gamemanager.Health - 100;
            GameObject.Find("ValeurHealth").GetComponent<Text>().text = gamemanager.Health.ToString();
        }
        else if (other.CompareTag("ShieldBoss"))
        {
            print("J'approche du bouclier");
            if (BouclierBoss)
            {
                Vector3 Bouclier = BouclierBoss.transform.position - transform.position;
                float sqrLen = Bouclier.sqrMagnitude;
                if (sqrLen <= DistanceBetweenPlayer * DistanceBetweenPlayer)
                {
                    gamemanager.Health = gamemanager.Health - 10;
                    GameObject.Find("ValeurHealth").GetComponent<Text>().text = gamemanager.Health.ToString();
                    print("Je prends des d�g�ts");

                }

            }
        }
        if (other.TryGetComponent<BossControl>(out var bossControl))
        {
            bossControl.SwapBossCameraActivation(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<BossControl>(out var bossControl))
        {
            bossControl.SwapBossCameraActivation(false);
        }
    }
    
    private void Update()
    {

    }

}
