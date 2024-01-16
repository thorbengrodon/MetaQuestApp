using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar1Script : MonoBehaviour
{

    Renderer renderer;
    Material selected;
    Material deselected;
    // Start is called before the first frame update
    void Start()
    {
        selected = Resources.Load<Material>("MyMaterials/Selected");
        deselected = Resources.Load<Material>("MyMaterials/Deselected");
        renderer = GetComponent<Renderer>();

        ChartSkript hallo = GetComponent<ChartSkript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        renderer.material = selected;

        renderer.material = ChartManager.testPink;



        Vector3 change = new Vector3(0.17f, 0.25f, 0.17f);
        transform.localScale = change;
        //transform.position = new Vector3(2.337f, 0.25f, 17.003f);


        GameObject bar2 = GameObject.Find("Bar2");
        //bar2.transform.localScale = change;
    }

    private void OnTriggerExit(Collider other)
    {
        renderer.material = deselected;
        Vector3 change = new Vector3(0.17f, 0.5f, 0.17f);
        //transform.position = new Vector3(2.337f, 0.5f, 17.003f);
        transform.localScale = change;
    }
}
