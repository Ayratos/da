using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleActivator1 : MonoBehaviour
{
    public GameObject[] triangles;
    private float activationregularity = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ForCoroutine", 5f);
        
    }
    private void ForCoroutine()
    {
        StartCoroutine(TrianglesActivation());
    }
    private void ForCoroutine2()
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
        DestroyTriangles();
        ActivateTriangles();
        StartCoroutine(TrianglesActivation());
    }
    void Update()
    {
        
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
