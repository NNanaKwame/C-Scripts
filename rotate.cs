using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [SerializeField] private float speed = 1.3f;
    void Update()
    {
        transform.Rotate(0,0,360 * speed * Time.deltaTime);
    }
}
