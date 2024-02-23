using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AJController : MonoBehaviour
{
    [SerializeField] float speed = 1.0f, curSpeed, runSpeed = 6.0f;
    [SerializeField] int rotationSpeed = 100, jumpforce = 200;
    [SerializeField] AudioClip sfxJump, sfxLanding, sfxDead, sfxWin;
    [SerializeField] int mouseSensibility = 200;
    Animator anim;
    Rigidbody rb;
    Transform groundcheck;
    bool IsGrounded;
    Camera cam;

    bool stop = false;
    AudioSource audioSourceAJ;
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        audioSourceAJ = GetComponent<AudioSource>();
        groundcheck = transform.Find("GroundCheck").GetComponent<Transform>();
        curSpeed = speed;
        cam = Camera.main;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible =false;
    }

    private void OnDisable() 
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    
    void Update()
    {
        if(stop) return;
        Move();
        Jump();
        MouseController();
    }

    private void Move() 
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        bool  runKeyPressed = Input.GetButton("Fire1");
        anim.SetBool("Running", runKeyPressed);
     
        curSpeed = runKeyPressed && v>0 ? runSpeed : speed ;
        transform.Translate(Vector3.forward * v * curSpeed * Time.deltaTime);

        if(v!= 0f && IsGrounded)
        transform.Rotate(Vector3.up * h * rotationSpeed * Time.deltaTime);
        
        anim.SetFloat("AxisV", v);
        

        anim.SetFloat("VelY", rb.velocity.y);
    }

    void Jump()
    {
        Collider[]  col = Physics.OverlapSphere(groundcheck.position, 0.2f, 3);
        IsGrounded = col.Length>0 ? true : false;
        anim.SetBool("IsGrounded", IsGrounded);
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.AddForce(Vector3.up * jumpforce);
            anim.SetTrigger("Jump");
            audioSourceAJ.PlayOneShot(sfxJump);
        }
    }

 void MouseController()
 {
    //PLayer Rotation
    if(Input.GetAxis("Vertical") !=0f && IsGrounded)
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X")*mouseSensibility * Time.deltaTime);
    }

    //Camera Rotate around player
    cam.transform.RotateAround(transform.position, Vector3.left,
    Input.GetAxis("Mouse Y")*100 * Time.deltaTime);
    cam.transform.localEulerAngles = new Vector3(cam.transform.localEulerAngles.x, 0, 0);
 }
    public void Dead()
    {
        anim.SetTrigger("Dying");
        stop = true;
        audioSourceAJ.PlayOneShot(sfxDead);
    }

    public void Win()
    {

        anim.SetTrigger("Win");
        stop = true;
        audioSourceAJ.clip = sfxWin;
        audioSourceAJ.loop = true;
        audioSourceAJ.Play();
    }
    public void PlaySoundLanding() 
    {
        audioSourceAJ.PlayOneShot(sfxLanding);

    }
}
