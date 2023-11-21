using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
public class navmeshbaker : MonoBehaviour
{
    public NavMeshSurface surface;

    // Start is called before the first frame update
    void Start()
    {
        surface.UpdateNavMesh(surface.navMeshData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
