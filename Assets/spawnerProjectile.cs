using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerProjectile : MonoBehaviour {


    public GameObject firepoint;
    public List<GameObject> vfx = new List<GameObject>();
    public rotateToMouse rotateToMouse;

    public float timeToFire = 0;
    private GameObject effectToSpawn;
	// Use this for initialization
	void Start () {
        effectToSpawn = vfx[0];
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0) && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / effectToSpawn.GetComponent<projectileMove>().fireRate;
            SpawnVFX();

        }
	}

    void SpawnVFX()
    {
        GameObject vfx;
        if (firepoint != null)
        {
            vfx = Instantiate(effectToSpawn, firepoint.transform.position, Quaternion.identity);
            if (rotateToMouse != null)
            {
                vfx.transform.localRotation = rotateToMouse.GetRotation();
            }
        }
        else
        {
            Debug.Log("No Fire Point");
        }
    }
}
