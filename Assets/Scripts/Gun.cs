using UnityEngine;
using GameCreator.Variables;

public class Gun : MonoBehaviour
{
    public float range = 100000000f;
    public GameObject audio;

    [SerializeField]
    //private Transform firePoint;//Point where laser beams will originate from

    public GameObject laserPrefab;
    public float fireRate;
    private float shootRateTimeStamp;
    public bool canShoot = false;

    RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && canShoot)
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
        if(Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            VariablesManager.SetGlobal("RaygunShot", true);

            Debug.Log(hit.transform.name);
            Debug.DrawRay(transform.position, transform.forward * 100, Color.red, 3f);

            GameObject laser = GameObject.Instantiate(laserPrefab, transform.position, transform.rotation) as GameObject;
            laser.GetComponent<ShotBehavior>().setTarget(hit.point);
            GameObject.Destroy(laser, 2f);
        }
    }
}
