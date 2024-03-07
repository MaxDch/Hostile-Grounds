using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController cc;
    const float GRAVITY = 9.81f;
    float velocityY;
    public GameObject valeurPv;
    [SerializeField] bool grounded;
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }



    // Update is called once per frame
    void Update()
    {
        //Move
        grounded = cc.isGrounded;
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
        cc.Move(movement*5f*Time.deltaTime);

        //Gravity

        if(cc.isGrounded && velocityY <0f) velocityY= 0f;

        velocityY -= GRAVITY * Time.deltaTime;
        cc.Move(Vector3.up*velocityY*Time.deltaTime);

        //Jump
        if(cc.isGrounded && Input.GetKeyDown(KeyCode.Space)) velocityY = 4.0f;
    }
}
