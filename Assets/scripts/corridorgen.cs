using Unity.Mathematics;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    //public Transform transform;
    //public Transform roomwall;
    public int size;
    public int quadsize;
    public GameObject quad;
    public bool generate = false;
    private void Update()
    {
        if (generate)
        {
            generate = false;
            kolanogen();
        }
    }
    public void roomgen()
    {
        Transform wallroot;
        float offset = size * quadsize;
        for (int i = 0; i < 4; i++)
        {
            wallroot = Instantiate(new GameObject("wallroot"),transform.position,quaternion.identity,transform).GetComponent<Transform>();
            
            wallroot.position += wallroot.right * offset*0.5f;
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    Instantiate(quad,wallroot.position + new Vector3(x*quadsize,y*quadsize) - new Vector3(offset*0.5f-quadsize/2, offset * 0.5f - quadsize / 2), quaternion.identity,wallroot);
                    
                }
            }
            wallroot.Rotate(0, 90, 0);
            transform.Rotate(0, 90, 0);
        }

        
    }
    public void kolanogen() 
    {
        float offset = size * quadsize;
        Transform wallroot;
        transform.Rotate(0, 90, 0);
        for (int i = 0; i < 3; i++)
        {
            wallroot = Instantiate(new GameObject("wallroot"), transform.position, quaternion.identity, transform).GetComponent<Transform>();
            
            wallroot.position += wallroot.right * offset * 0.5f;
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    Instantiate(quad, wallroot.position + new Vector3(x * quadsize, y * quadsize) - new Vector3(offset * 0.5f - quadsize / 2, offset * 0.5f - quadsize / 2), quaternion.identity, wallroot);

                }
            }
            wallroot.Rotate(0, 90, 0);
            transform.Rotate(0, 90, 0);
        }
        wallroot = Instantiate(new GameObject("wallroot"), transform.position, quaternion.identity, transform).GetComponent<Transform>();
        
        wallroot.position += wallroot.up * offset * 0.5f;
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                Instantiate(quad, wallroot.position + new Vector3(x * quadsize, y * quadsize) - new Vector3(offset * 0.5f - quadsize / 2, offset * 0.5f - quadsize / 2), quaternion.identity, wallroot);

            }
        }
        wallroot.Rotate(-90, 0, 0);
        //roomroot.Rotate(90, 0, 0);
    }
}
