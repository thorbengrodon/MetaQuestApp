using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChartSkript : MonoBehaviour
{
    public GameObject bar1;
    public float test;
    // Start is called before the first frame update
    void Start()
    {
        bar1 = GameObject.Find("Bar1");
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        Material selected = Resources.Load<Material>("MyMaterials/Selected");
        Renderer rend1 = bar1.GetComponent<Renderer>();
        rend1.material = selected;
    }

    private void OnTriggerExit(Collider other)
    {
        Material selected = Resources.Load<Material>("MyMaterials/Deselected");
        Renderer rend1 = bar1.GetComponent<Renderer>();
        rend1.material = selected;
    }
}
