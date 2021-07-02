using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    public GameObject Player;
    public float TargetDistance;
    public float AllowedDistance = 5;
    public GameObject NPC;
    public float FollowSpeed;
    public RaycastHit Shot;
    

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = new Vector3(0, (float)1, 0);
        transform.LookAt(Player.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot)) 
        {
            TargetDistance = Shot.distance;
            if (TargetDistance>=AllowedDistance)
            {
                FollowSpeed = 0.009f;
                NPC.GetComponent<Animator>().Play("walking");
                transform.position = Vector3.MoveTowards(transform.position, Player.transform.position - offset, FollowSpeed);
            }
            else
            {
                FollowSpeed = 0;
                NPC.GetComponent<Animator>().Play("idle");
            }
        }
    }
}
