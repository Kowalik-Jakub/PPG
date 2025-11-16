using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public PlayerAim aimScript;
    public GameObject bulletPrefab2;
    private bool useSecondBullet = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            useSecondBullet = !useSecondBullet;

        if (Input.GetMouseButtonDown(0) && aimScript.IsAiming())
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject prefab = useSecondBullet ? bulletPrefab2 : bulletPrefab;
        Instantiate(prefab, firePoint.position, firePoint.rotation);
    }
}
