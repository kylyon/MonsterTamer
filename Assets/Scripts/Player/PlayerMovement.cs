using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform playerTransform;
    public float playerSpeed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var xMove = Input.GetAxis("Horizontal");
        var zMove = Input.GetAxis("Vertical");

        playerTransform.position += new Vector3(xMove, 0, zMove).normalized * playerSpeed * Time.deltaTime;
    }
}
