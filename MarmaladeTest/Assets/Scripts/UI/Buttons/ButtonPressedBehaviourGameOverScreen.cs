using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPressedBehaviourGameOverScreen : ButtonPressedBehaviour
{
    public override void OnPressed(GameObject presenterGameObject)
    {
        presenterGameObject.GetComponent<GameOverPresenter>().GoToMainMenu();
        //SceneManager.LoadScene(SceneToChangeName);
    }
}
