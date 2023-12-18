using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer_Script : MonoBehaviour
{
    public TMP_Text timer_Text;
    public float time_Value = 0.0f;//starts with 0
    public float timeLimit = 60.0f;//60 seconds
    public SceneTransitionManager sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        timer_Text.text = "Time: " + (int)(timeLimit);
    }

    // Update is called once per frame
    void Update()
    {
        time_Value += Time.deltaTime;

        timer_Text.text = "Time: " + (int)(timeLimit - time_Value);
        if ((timeLimit - time_Value) <=0) { //time runs out
            sceneManager.GoToScene(1);
        }
    }
}
