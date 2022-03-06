using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    List<Enemy> pawns;

    
    Quaternion SpawnRotation = Quaternion.Euler(0, 0, 0);

 
    private void Awake()
    {
        pawns = new List<Enemy>();
        GetComponentInChildren<Trigger>().MotherShipTriggerEvent.AddListener(delegate { Spawn(); });
    }
    void Spawn()
    {
        GameObject temp = Instantiate(enemy, new Vector3(transform.position.x, 1, transform.position.z), SpawnRotation);
        temp.transform.parent = gameObject.transform;
        pawns.Add(temp.GetComponent<Enemy>());
        pawns[pawns.Count - 1].type = Random.Range(1, 3);
        pawns[pawns.Count -1].DeathEvent.AddListener(delegate { PawnDown(pawns[pawns.Count-1]); });

    
    }
    public void DestroyPawns()
    {
        for (int i = 0; i < pawns.Count; i++)
            Destroy(pawns[i].gameObject);
        pawns.Clear();
    }
    void PawnDown(Enemy p)
    {
        pawns.Remove(p);
    }

}
/*
 class MotherShip
    DataMembers:
        GameObject enemy;

        List<Enemy> pawns;

        Quaternion SpawnRotation;

     Functions:
        Spawn();

*/