using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHorizontalFollow : MonoBehaviour
{
    [SerializeField] Transform playerCharacter;

    void Update()
    {
        transform.position = new Vector3(playerCharacter.position.x, transform.position.y, playerCharacter.position.z);
    }
}
