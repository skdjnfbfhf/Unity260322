using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Babu
{
    public class Map : MonoBehaviour
    {
        public Transform Player;
        public float intervalX = 20.0f;
        public float intervalZ = 20.0f;
        public List<Transform> planes = new List<Transform>();
        Vector2 currentPos;

        void Start()
        {
            Player = GameObject.FindWithTag("Player").transform;

            for(int i = 0; i < this.transform.childCount; i++)
            {
                planes.Add(this.transform.GetChild(i));
            }
        }

        void Update()
        {
            Vector2 playerInterval = new Vector2(Mathf.Floor(Player.position.x / intervalX),
                Mathf.Floor(Player.position.z / intervalZ));

            if(playerInterval != currentPos)
            {
                currentPos = playerInterval;
                UpdateMap();
            }
        }

        void UpdateMap()
        {
            int i = 0;
            for (int x = -1; x <= 1; x++)
            {
                for (int z = -1; z <= 1; z++)
                {
                    Vector3 pos = new Vector3((currentPos.x + x) * intervalX, 0,
                        (currentPos.y + z) * intervalZ);
                    planes[i].position = pos;
                    i++;
                }
            }
        }



    }
}
