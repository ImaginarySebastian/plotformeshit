using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife2 : MonoBehaviour
{
    [SerializeField] float speed = 10F;
    void Update()
    {
        transform.Translate((transform.forward * speed * Time.deltaTime));
    }
}
