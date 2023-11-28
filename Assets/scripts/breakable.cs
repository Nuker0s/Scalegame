using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class breakable : MonoBehaviour
{
    public GameObject[] vanish;
    public Transform[] cellparents;
    public Transform[] deatach;
    public GameObject cellstorage;
    public float maxforce;
    public bool breaker = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (breaker)
        {
            breaker = false;
            breaking(transform.position,5,2);
        }
    }
    public void breaking(Vector3 from,float force,float radius) 
    {
        foreach (Transform cellparent in cellparents)
        {
            cellparent.gameObject.SetActive(true);
            Debug.Log("activated");
            cellparent.parent = null;
            foreach (Transform cellchild in cellparent) 
            {
                //cellchild.parent = cellstorage.transform;
                Rigidbody cell = cellchild.GetComponent<Rigidbody>();
                
                cell.isKinematic = false;
                cell.AddExplosionForce(force, from, radius);
                //cell.AddForce(Random.Range(0, maxforce), Random.Range(0, maxforce), Random.Range(0, maxforce));
                
                
            }
            
        }
        foreach(Transform todeatach in deatach) 
        {
            todeatach.parent = null;
            if (todeatach.gameObject.TryGetComponent(out Rigidbody drb)) 
            {
                drb.isKinematic = false;
            }
        }
        foreach (GameObject item in vanish) 
        {
            Destroy(gameObject);
        }
    }
}
