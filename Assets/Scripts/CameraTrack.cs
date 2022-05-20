using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    //CODIGO INUTIL PORFAVOR NO USAR
    public GameObject player;
    public float distanceY;
    public float distanceZ;
    public Transform camPos;
    public float ditanceCamPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        camPos.position = new Vector3(player.transform.position.x, player.transform.position.y + ditanceCamPos, player.transform.position.z);
        transform.LookAt(camPos);
        transform.position = player.transform.position + new Vector3(0,distanceY,distanceZ);
    }
}
