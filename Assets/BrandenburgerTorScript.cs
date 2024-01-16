using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrandenburgerTorScript : MonoBehaviour
{
    Material selected;
    Material deselected;
    Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        selected = Resources.Load<Material>("MyMaterials/Selected");
        deselected = Resources.Load<Material>("MyMaterials/Deselected");
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //renderer.material = selected;
        Vector3 newScale = transform.localScale;
        newScale *= 1.6F;
        transform.localScale = newScale;
    }

    private void OnTriggerExit(Collider other)
    {
        //renderer.material = deselected;
        Vector3 newScale = transform.localScale;
        newScale *= 0.625F;
        transform.localScale = newScale;
    }
}
