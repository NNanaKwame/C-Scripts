using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private Transform Him;

    void Update()
    {
        transform.position = new Vector3(Him.position.x,Him.position.y,transform.position.z);
    }
}
