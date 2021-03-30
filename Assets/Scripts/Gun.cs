using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 100f;

    [SerializeField]
    private Transform firePoint;//Point where laser beams will originate from

    public GameObject laserPrefab;
    public float fireRate;
    private float shootRateTimeStamp;

    RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(Time.time > shootRateTimeStamp)
            {
                Shoot();
                shootRateTimeStamp = Time.time + fireRate;
            }
        }
    }

    void Shoot()
    {
        if(Physics.Raycast(firePoint.position, firePoint.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.red, 3f);

            GameObject laser = GameObject.Instantiate(laserPrefab, transform.position, transform.rotation) as GameObject;
            //laser.GetComponent<ShotBehavior>().setTarget(hit.point);
            GameObject.Destroy(laser, 2f);
        }
    }
}
