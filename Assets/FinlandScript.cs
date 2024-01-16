using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FinlandScript : MonoBehaviour
{
    Material selected;
    Material deselected;
    Renderer renderer;

    GameObject finlandGraph;
    Material selectedGraph;
    Material deseletedGraph;

    TMP_Text label1;
    TMP_Text label2;

    // Start is called before the first frame update
    void Start()
    {
        selected = Resources.Load<Material>("MyMaterials/Selected");
        deselected = Resources.Load<Material>("MyMaterials/Deselected");
        renderer = GetComponent<Renderer>();

        finlandGraph = GameObject.Find("FinlandFlow");
        selectedGraph = Resources.Load<Material>("MyMaterials/SelectedGraph");
        deseletedGraph = Resources.Load<Material>("MyMaterials/DeselectedGraph");

        label1 = GameObject.Find("finlandLabel1").GetComponent<TMP_Text>();
        label1.text = "";
        label2 = GameObject.Find("finlandLabel2").GetComponent<TMP_Text>();
        label2.text = "";

        Renderer[] renderers = finlandGraph.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetComponent<MeshRenderer>().material = deseletedGraph;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        Scene scene = SceneManager.GetActiveScene();
        string name = scene.name;

        if (string.Equals(name, "Dataset2021"))
        {
            label1.text = ChartManager.finland_estonia[0].ToString() + " GWH";
            label2.text = ChartManager.finland_sweden[0].ToString() + " GWH";
        }

        if (string.Equals(name, "Dataset2010"))
        {
            label1.text = ChartManager2010.finland_estonia[0].ToString() + " GWH";
            label2.text = ChartManager2010.finland_sweden[0].ToString() + " GWH";
        }

        if (string.Equals(name, "Dataset2000"))
        {
            label1.text = ChartManager2000.finland_estonia[0].ToString() + " GWH";
            label2.text = ChartManager2000.finland_sweden[0].ToString() + " GWH";
        }



        renderer.material = selected;
        Renderer[] renderers = finlandGraph.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetComponent<MeshRenderer>().material = selectedGraph;
        }


        float[] values = ChartManager.finland;
        NewChartSkript.updateChart(values[0] / 100, values[1] / 100, values[2] / 100, values[3] / 100, values[4] / 100, values[5] / 100, "Finland", selected);
    }

    private void OnTriggerExit(Collider other)
    {
        label1.text = "";
        label2.text = "";

        renderer.material = deselected;
        Renderer[] renderers = finlandGraph.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetComponent<MeshRenderer>().material = deseletedGraph;
        }
    }
}
