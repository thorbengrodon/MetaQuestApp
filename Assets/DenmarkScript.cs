using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DenmakrScript : MonoBehaviour
{
    Material selected;
    Material deselected;
    Renderer renderer;

    GameObject denmarkGraph;
    Material selectedGraph;
    Material deseletedGraph;

    TMP_Text label1;
    TMP_Text label2;
    TMP_Text label3;

    // Start is called before the first frame update
    void Start()
    {
        selected = Resources.Load<Material>("MyMaterials/Selected");
        deselected = Resources.Load<Material>("MyMaterials/Deselected");
        renderer = GetComponent<Renderer>();

        denmarkGraph = GameObject.Find("DenmarkFlow");
        selectedGraph = Resources.Load<Material>("MyMaterials/SelectedGraph");
        deseletedGraph = Resources.Load<Material>("MyMaterials/DeselectedGraph");

        label1 = GameObject.Find("denmarkLabel1").GetComponent<TMP_Text>();
        label1.text = "";
        label2 = GameObject.Find("denmarkLabel2").GetComponent<TMP_Text>();
        label2.text = "";
        label3 = GameObject.Find("denmarkLabel3").GetComponent<TMP_Text>();
        label3.text = "";

        Renderer[] renderers = denmarkGraph.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetComponent<MeshRenderer>().material = deseletedGraph; ;
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
            label1.text = ChartManager.denmark_sweden[0].ToString() + " GWH";
            label2.text = ChartManager.denmark_germany[0].ToString() + " GWH";
            label3.text = ChartManager.denmark_netherland[0].ToString() + " GWH";
        }

        if (string.Equals(name, "Dataset2010"))
        {
            label1.text = ChartManager2010.denmark_sweden[0].ToString() + " GWH";
            label2.text = ChartManager2010.denmark_germany[0].ToString() + " GWH";
            label3.text = ChartManager2010.denmark_netherland[0].ToString() + " GWH";
        }

        if (string.Equals(name, "Dataset2000"))
        {
            label1.text = ChartManager2000.denmark_sweden[0].ToString() + " GWH";
            label2.text = ChartManager2000.denmark_germany[0].ToString() + " GWH";
            label3.text = ChartManager2000.denmark_netherland[0].ToString() + " GWH";
        }

        if (string.Equals(name, "IntroScene"))
        {
            label1.text = XYTest.denmark_sweden[0].ToString() + " GWH";
            label2.text = XYTest.denmark_germany[0].ToString() + " GWH";
            label3.text = XYTest.denmark_netherland[0].ToString() + " GWH";
        }



        renderer.material = selected;
        Renderer[] renderers = denmarkGraph.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetComponent<MeshRenderer>().material = selectedGraph;
        }

        float[] values = ChartManager.denmark;
        NewChartSkript.updateChart(values[0] / 100, values[1] / 100, values[2] / 100, values[3] / 100, values[4] / 100, values[5] / 100, "Denmark", selected);
    }

    private void OnTriggerExit(Collider other)
    {

        label1.text = "";
        label2.text = "";
        label3.text = "";

        renderer.material = deselected;
        Renderer[] renderers = denmarkGraph.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].GetComponent<MeshRenderer>().material = deseletedGraph; ;
        }
    }
}
