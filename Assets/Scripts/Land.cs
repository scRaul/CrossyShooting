using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Land : MonoBehaviour
{
    MotherShip motherShip;

    [SerializeField] List<GameObject> obsticles = new List<GameObject>();
    private void Awake()
    {
        
        int index = Random.Range(0,obsticles.Count);

        var building = Instantiate(obsticles[index], transform.position + new Vector3(0,2,0), obsticles[index].transform.rotation);
        building.transform.parent = this.transform;
        motherShip = GetComponentInChildren<MotherShip>();
    }
    public void InfromMotherShip()
    {
        if(motherShip != null)
            motherShip.DestroyPawns();
    }
}
/*
 Class Land

    Data members:

        MotherShip motherShip;

    Functions:

        Awake()
        InfromMotherShip(); //tells mothership when its about to be destroyed
 */