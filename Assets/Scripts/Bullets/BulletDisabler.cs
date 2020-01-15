using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Outfit7.Interface;

public class BulletDisabler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IShootable>() != null)
        {
            other.gameObject.SetActive(false);
        }
    }
}
