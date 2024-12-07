using System;
using UnityEngine;

public class FruitsTrigger : MonoBehaviour
{
    public static Action<bool> onTrigger;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
        }
    }
}