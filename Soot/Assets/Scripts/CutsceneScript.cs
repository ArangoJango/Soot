using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneScript : MonoBehaviour
{
    public GameObject Cutscene;
    public float destroyTime = 5f;
    // Start is called before the first frame update
    void Start()
    {        
        StartCoroutine(DestroyObject());
        //Time.timeScale = 0;
    }
    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(Cutscene);
        //Time.timeScale = 1;
    }
}
