using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;

    private void Update()
    {

        transform.position = new Vector3(player.transform.position.x + 0, player.transform.position.y, -10);
    }
}
