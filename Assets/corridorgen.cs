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
            GameObject wallroot = Instantiate(new GameObject("wallroot"),roomroot.position,roomroot.rotation,roomroot);
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {

                }
            }
            roomroot.Rotate(0, 90 * i, 0);
        }

    }
}
