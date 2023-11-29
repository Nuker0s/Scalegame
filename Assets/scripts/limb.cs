using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class limb : MonoBehaviour
{
    public Transform endlimb;
    public LineRenderer line;
    
    // Start is called before the first frame update
    void Start()
    {
        if (line==null)
        {
            line = GetComponent<LineRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        line.SetPosition(0, transform.position);
        line.SetPosition(1, endlimb.position);
    }
}
