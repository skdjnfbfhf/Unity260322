using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

namespace Babu
{
    public class Player : MonoBehaviour
    {
        public float maxSpeed = 10.0f;
        public float currentSpeed = 0.0f;
        public float increaseSpeed = 10.0f;
        public float decreaseSpeed = 5.0f;
        public float backSpeed = 5.0f;
        public float rotSpeed = 200.0f;
        public float hp = 100f;

        //public GameObject bombEffect; delete?
        public int bombCnt = 3;
        public float knockbackPower = 10f;
        public float knockbaxkTime = 0.2f;

        Rigidbody rb;
        [SerializeField]
        bool isBtn1 = true;
        [SerializeField]
        bool isBtn2 = true;
        [SerializeField]
        bool isBtn3 = true;

        public bool isReflect = false;

        [SerializeField]
        float reflectTime = 3.0f;
        public GameObject Reflect;
        public GameObject BlackHole;
        public GameObject SlowHole;
        public GameObject DebugActive;

       void Start()
        {
            rb = GetComponent<Rigidbody>();
            //if (!GameManager.instance.isDebug)
            //{

            //}
        }

        void Update()
        {
            Move();
        }

        void Move()
        {
            if (Input.GetKey(KeyCode.W))
            {
                currentSpeed += increaseSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                currentSpeed -= backSpeed * Time.deltaTime;
            }
            currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
            if ( Input.GetKey(KeyCode.A))
            {
                transform.Rotate(-Vector3.up * rotSpeed * Time.deltaTime);
            }
            if(Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
            }
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        }


    }
}
