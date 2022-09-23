using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raytest : MonoBehaviour
{
    [SerializeField] private Vector3 collision = Vector3.zero;
    private GameObject lastHit;
    [SerializeField] private int raycastDist = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        var ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, raycastDist))
        {
            lastHit = hit.transform.gameObject;
            Debug.Log(lastHit);
            collision = hit.point;
        }
    }

    private void OnDrawGizmos()
    {
        Update();
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(collision, 0.2f);
    }

}
