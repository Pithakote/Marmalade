using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuModel : MonoBehaviour
{
    [SerializeField] private string nameOfSceneToChangeTo;

    public void ChangeScene()
    {
        SceneManager.LoadScene(nameOfSceneToChangeTo);
    }
}
