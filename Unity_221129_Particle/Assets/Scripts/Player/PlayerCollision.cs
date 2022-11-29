using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            ParticleManager.instance.Play("EnergyExplosion", other.transform.position, other.transform.rotation);
        }
    }
}
