using Outfit7.Interface;
using UnityEngine;

public class BulletDisabler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IKillable>() != null || other.GetComponent<IShootable>() != null)
        {
            other.gameObject.SetActive(false);
        }
    }
}
