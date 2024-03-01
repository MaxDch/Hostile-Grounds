using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTwoObjectAxis : MonoBehaviour
{
    [SerializeField] Transform FollowObject_1;
    [SerializeField] Transform FollowObject_2;

    [SerializeField] bool assignPlayerToFollowObject2;

    public float moveSmoothTime;
    public float rotateSmoothTime;

    Vector3 moveVelocity;
    Vector3 rotateVelocity;
    void Start()
    {
        if(assignPlayerToFollowObject2)
        {
            FollowObject_2 = FindObjectOfType<ThirdPersonController>().transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        Vector3 objet1HorizontalPosition = new Vector3(FollowObject_1.position.x, 0, FollowObject_1.position.z);
        Vector3 objet2HorizontalPosition = new Vector3(FollowObject_2.position.x, 0, FollowObject_2.position.z);
        Vector3 horizontalDirection = (objet2HorizontalPosition - objet1HorizontalPosition).normalized;

        Vector3 targetLookAt = transform.position - horizontalDirection;

        transform.LookAt(Vector3.SmoothDamp(transform.position + transform.forward, targetLookAt, ref rotateVelocity, rotateSmoothTime));
        transform.position = Vector3.SmoothDamp(transform.position, FollowObject_2.position - horizontalDirection, ref moveVelocity, moveSmoothTime);
    }
}
