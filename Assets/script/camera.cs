using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;
    public Vector3 offSite = new Vector3(0, 0, -10);
    public float camSpeed = 0.011f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = Player.position + offSite;
        Vector3 real = Vector3.Lerp(transform.position, playerPosition, camSpeed);
        transform.position = real;
    }
}
