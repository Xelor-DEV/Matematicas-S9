using UnityEngine;

public class MRUandMRUV : MonoBehaviour
{
    [SerializeField] private GameObject objectMRU;  
    [SerializeField] private GameObject objectMRUV;

    [SerializeField] private float voMRU; 
    [SerializeField] private float tMRU;

    [SerializeField] private float voMRUV; 
    [SerializeField] private float tMRUV;  
    [SerializeField] private float aMRUV; 

    void Update()
    {
        float xMRU = voMRU * tMRU;
        objectMRU.transform.position = new Vector3(xMRU, objectMRU.transform.position.y, objectMRU.transform.position.z);
        float xMRUV = voMRUV * tMRUV + 0.5f * aMRUV * tMRUV * tMRUV;
        objectMRUV.transform.position = new Vector3(xMRUV, objectMRUV.transform.position.y, objectMRUV.transform.position.z);
    }
}
