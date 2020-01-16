using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Outfit7.Enemy
{
    public class EnemyPath : Enemy
    {
        private Vector3[] m_waypointsPositions;
        private Vector3 m_screenBounds;
        private Camera m_mainCamera;
        private PathType pathType = PathType.CatmullRom;
        private Tween m_followPath;

        private void OnEnable()
        {
            base.OnEnable();

            if(m_waypointsPositions != null)
                m_followPath = transform.DOPath(m_waypointsPositions, m_spaceshipModel.Speed, pathType);
        }

        public void SetPositions(Transform[] m_waypoints)
        {
            if (m_waypoints.Length == 0)
                return;

            m_waypointsPositions = new Vector3[m_waypoints.Length];

            for (int i = 0; i < m_waypoints.Length; i++)
            {
                m_waypointsPositions[i] = m_waypoints[i].position;
            }
        }

        private void OnDisable()
        {
            m_followPath.Kill();
        }
    }

}

