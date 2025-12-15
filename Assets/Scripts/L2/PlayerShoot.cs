using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public PlayerAim aimScript;

    private PlayerStats stats;
    private bool useSecondBullet = false;

    void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            useSecondBullet = !useSecondBullet;

        if (Input.GetMouseButtonDown(0) && aimScript.IsAiming())
        {
            if (stats.TryConsumeAmmo(1))
            {
                Shoot();
            }
            else
            {
                Debug.Log("Brak amunicji!");
            }
        }
    }

    void Shoot()
    {
        GameObject prefab = useSecondBullet ? bulletPrefab2 : bulletPrefab;
        Instantiate(prefab, firePoint.position, firePoint.rotation);
    }
}
