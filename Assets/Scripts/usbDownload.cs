using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;


public class usbDownload : MonoBehaviour
{
    [SerializeField]
    public Slider progressSlider;
    public int delay;
    public SocketWithTagCheck socket;

    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        progressSlider.value = 0;



        coroutine = DownloadCoroutine(); 
        StartCoroutine(coroutine);
    }

    IEnumerator DownloadCoroutine()
    {

        while (true)
        {
            if (socket == null)
            {
                Debug.LogWarning("Socket not assigned in the Inspector.");
                yield break; // Exit the coroutine if socket is not assigned
            }

            if (socket.hasSelection && progressSlider.value < 100)
            {
                progressSlider.value += 1;
                yield return new WaitForSeconds(delay);
                Debug.Log(progressSlider.value);
            }
            else if (progressSlider.value == 100)
            {
                Debug.Log("Finished Downloading");
                yield break; // Exit the coroutine when download is complete
            }

            yield return null; // Wait for the next frame before checking again
        }
    }

}