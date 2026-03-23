using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Babu
{
    public class FollowCamera : MonoBehaviour
    {

        public Transform Player;
        void Start()
        {
            Player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        // Update is called once per frame
        void Update()
        {
            this.transform.position = new Vector3(Player.position.x,
                this.transform.position.y, Player.position.z);
        }
    }
}
