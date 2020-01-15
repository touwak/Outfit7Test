using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Outfit7.Enviroment
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlanetContoller : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody m_rigidbody;

        private Vector3 m_randomRotation;
        private Vector3 m_randomScale;
        private float m_rotationDuration;
        Tween m_rotationTween;
        private float m_movementVelocity;

        private void OnEnable()
        {
            m_randomRotation = new Vector3
            {
                x = Random.Range(0f, 256f),
                y = Random.Range(0f, 256f),
                z = Random.Range(0f, 256f)
            };
            m_rotationDuration = Random.Range(2f, 10f);
            m_rotationTween = transform.DORotate(m_randomRotation * 180, m_rotationDuration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);

            m_movementVelocity = Random.Range(0.1f, 2f);
            m_rigidbody.velocity = Vector3.down * m_movementVelocity;
        }

        private void OnDisable()
        {
            m_rotationTween.Kill();
            m_rigidbody.velocity = Vector3.zero;
        }
    }
}
