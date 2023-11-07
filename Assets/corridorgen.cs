using Unity.Mathematics;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public Transform roomroot;
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
            roomgen();
        }
    }
    public void roomgen()
    {
        for (int i = 0; i < 4; i++)
        {
            Transform wallroot = Instantiate(new GameObject("wallroot"),roomroot.position,quaternion.identity,roomroot).GetComponent<Transform>();
            float offset = size * quadsize;
            wallroot.position += wallroot.right * offset*0.5f;
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    Instantiate(quad,wallroot.position + new Vector3(x*quadsize,y*quadsize) - new Vector3(offset*0.5f-quadsize/2, offset * 0.5f - quadsize / 2), quaternion.identity,wallroot);
                    
                }
            }
            wallroot.Rotate(0, 90, 0);
            roomroot.Rotate(0, 90, 0);
        }

    }
}
