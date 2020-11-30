using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AdditiveSceneLoader : MonoBehaviour
{
    [SerializeField]
    private string sceneName; 
    private void Start()
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }

}
