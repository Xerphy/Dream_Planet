using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 100f;

    [SerializeField]
    private Transform firePoint;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(firePoint.position, firePoint.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.red, 3f);
        }
    }
}
