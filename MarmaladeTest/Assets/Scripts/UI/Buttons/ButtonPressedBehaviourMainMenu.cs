using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPressedBehaviourMainMenu : ButtonPressedBehaviour
{
    
    public override void OnPressed(GameObject presenterGameObject)
    {
        presenterGameObject.GetComponent<MainMenuPresenter>().GoToGame();
        //SceneManager.LoadScene(SceneToChangeName);
    }
}
