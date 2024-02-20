using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform playerTransform;
    public float playerSpeed = 1f;

    private CharacterController cc;
    
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var xMove = Input.GetAxis("Horizontal"); // Gauche droite
        var zMove = Input.GetAxis("Vertical"); // Avant arrière
        
        cc.Move(new Vector3(xMove * transform.right.x + zMove * transform.forward.x, 0, xMove * transform.right.z + zMove * transform.forward.z).normalized * playerSpeed * Time.deltaTime);
        
        //playerTransform.position += ;
    }
}
