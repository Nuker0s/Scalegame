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
            breaking();
        }
    }
    public void breaking() 
    {
        foreach (Transform cellparent in cellparents)
        {
            cellparent.gameObject.SetActive(true);
            cellparent.parent = null;
            foreach (Transform cellchild in cellparent) 
            {
                //cellchild.parent = cellstorage.transform;
                Rigidbody cell = cellchild.GetComponent<Rigidbody>();
                cell.isKinematic = false;
                cell.AddForce(Random.Range(0, maxforce), Random.Range(0, maxforce), Random.Range(0, maxforce));
                
                
            }
            
        }
        foreach(Transform todeatach in deatach) 
        {
            todeatach.parent = null;
            if (todeatach.gameObject.GetComponent<Rigidbody>() != null) 
            {
                todeatach.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
        foreach (GameObject item in vanish) 
        {
            Destroy(gameObject);
        }
    }
}
