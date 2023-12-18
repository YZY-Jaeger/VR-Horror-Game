using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class bodySocket
{   
   
  
    public GameObject gameObject;
    [Range(0.01f, 2f)]
    public float heightRatio;
}


public class BodySocketInventory : MonoBehaviour

{
    public GameObject HMD;
    public bodySocket[] bodySockets;

    private Vector3 _currentHMDlocalPosition;
   
    void Update()
    {
        _currentHMDlocalPosition = HMD.transform.localPosition;
       

    foreach (var bodySocket in bodySockets)
        {
            UpdateBodySocketHeight(bodySocket);
        }
        UpdateSocketInventory();
    }

    private void UpdateBodySocketHeight(bodySocket bodySocket)
    {
        bodySocket.gameObject.transform.localPosition = new Vector3(bodySocket.gameObject.transform.localPosition.x,(_currentHMDlocalPosition.y - 1.5f + bodySocket.heightRatio), bodySocket.gameObject.transform.localPosition.z);
    }

    private void UpdateSocketInventory()
    {
        transform.localPosition = new Vector3(_currentHMDlocalPosition.x, 0, _currentHMDlocalPosition.z);
       // transform.rotation = new Quaternion(transform.rotation.x, _currentHMDRotation.y, transform.rotation.z, _currentHMDRotation.w);
    }
}