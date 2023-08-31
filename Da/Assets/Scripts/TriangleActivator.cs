using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleActivator : MonoBehaviour
{
    public GameObject[] triangles;
    private float activationregularity = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TrianglesActivation());
        Invoke("ForCoroutine", activationregularity);
    }
    private void ForCoroutine()
    {
        StartCoroutine(TrianglesDisActivation());
    }
    IEnumerator TrianglesDisActivation()
    {
        DestroyTriangles();
        yield return new WaitForSeconds(activationregularity);
        StartCoroutine(TrianglesDisActivation());
    }
    IEnumerator TrianglesActivation()
    {
        yield return new WaitForSeconds(activationregularity);
        ActivateTriangles();
        StartCoroutine(TrianglesActivation());
    }

    private void DestroyTriangles()
    {
        foreach (GameObject triangle  in triangles)
        {
            triangle.SetActive(false);
        }
    }
    private void ActivateTriangles()
    {
        int triangelcounter = Random.Range(1, 10);
        do
        {
            int randomIndex = Random.Range(0,triangles.Length);
            triangles[randomIndex].SetActive(true);
            --triangelcounter;
        } while (triangelcounter != 0);
        
    }
    
}
