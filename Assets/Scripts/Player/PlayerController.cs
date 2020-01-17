using DG.Tweening;
using Outfit7.Bullet;
using Outfit7.Interface;
using Outfit7.Spaceship;
using UnityEngine;

namespace Outfit7.Player
{
    public class PlayerController : SpaceshipController, IShooter
    {
        [Header("Components")]
        [SerializeField]
        private PlayerView m_playerView;
        [SerializeField]
        private Transform m_bulletsParent;

        private Vector3 m_newPosition;
        Touch m_touch;
        Vector3 m_touchPosition;
        private Camera m_mainCamera;
        private float m_nextFire = 0f;
        private BulletPool m_bulletPool;
        private Vector3 m_screenBounds;
        private float m_shipWidth;

        private void Awake()
        {
            m_newPosition = transform.position;
            m_mainCamera = Camera.main;
            m_bulletPool = (BulletPool)FindObjectOfType(typeof(BulletPool));
            m_screenBounds = m_mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, m_mainCamera.transform.position.z));
            m_shipWidth = GetComponent<BoxCollider>().bounds.extents.x;
        }

        private void Update()
        {
            // TODO change to touch

            //if (Input.touchCount > 0)
            //{
            //    PlayerMovement();

            //    if (Time.time > m_nextFire)
            //    {
            //        Fire(m_bulletPool.GetPlayerBullet());
            //    }
            //}

            if (Input.GetMouseButton(0))
            {
                PlayerMovement();

                if (Time.time > m_nextFire)
                {
                    Fire(m_bulletPool.GetPlayerBullet());
                }
            }
        }

        public void Fire(BulletController bullet)
        {
            if (bullet != null)
            {
                m_nextFire = Time.time + m_fireRate;

                bullet.transform.position = m_bulletsParent.position;
                bullet.transform.rotation = m_bulletsParent.rotation;
                bullet.Rigidbody.velocity = Vector3.up * bullet.Speed;

                m_playerView.PlayShootSound();
            }
        }

        private void PlayerMovement()
        {
            // TODO change to touch

            //m_touch = Input.GetTouch(0);
            //m_touchPosition = m_touch.position;

            m_touchPosition = Input.mousePosition;


            m_touchPosition.z = transform.position.z - m_mainCamera.transform.position.z;
            m_newPosition.x = Mathf.Clamp(m_mainCamera.ScreenToWorldPoint(m_touchPosition).x, m_screenBounds.x + m_shipWidth, m_screenBounds.x * -1 - m_shipWidth);

            transform.position = m_newPosition;
        }

        private new void OnTriggerEnter(Collider other)
        {
            BulletController bulletController = other.GetComponent<BulletController>();
            if (bulletController != null && !bulletController.CompareTag(this.tag))
            {
                m_mainCamera.DOShakePosition(0.5f, 1f, 10);
                Damage(bulletController.Damage);
                m_playerView.SetHealthSlider(m_health / m_spaceshipModel.Health);
                other.gameObject.SetActive(false);
            }

            if (other.GetComponent<IPowerUp>() != null)
            {
                switch (other.tag)
                {
                    case "PU_Shield":
                        m_playerView.ActiveShield();
                        break;
                    case "PU_Damage":
                        m_playerView.ActivePUMoreDamage();
                        break;
                    default:
                        Debug.Log(string.Concat("Wrong Power Up tag: ", other.tag));
                        break;
                }

                other.gameObject.SetActive(false);
            }
        }

        private void OnDisable()
        {
            ReferenceVault.Instance.GameManager.ShowGameOverMenu(true);
        }
    }
}