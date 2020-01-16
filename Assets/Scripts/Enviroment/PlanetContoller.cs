using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Outfit7.Enviroment
{
    public class PlanetContoller : MonoBehaviour
    {
        private Vector3 m_randomRotation;
        private Vector3 m_randomScale;
        private float m_rotationDuration;
        Tween m_rotationTween;
        private float m_movementVelocity;

        private void Start()
        {
            m_randomRotation = new Vector3
            {
                x = Random.Range(0f, 360f),
                y = Random.Range(0f, 360f),
                z = Random.Range(0f, 360f)
            };
            m_rotationDuration = Random.Range(2f, 10f);
            m_rotationTween = transform.DORotate(m_randomRotation * 180, m_rotationDuration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
        }

        private void OnDisable()
        {
            m_rotationTween.Kill();
        }
    }
}
