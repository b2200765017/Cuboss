using UnityEngine;
using UnityEngine.SceneManagement;
public class Loader : MonoBehaviour
{
public enum  Scene
{
    Main,
    Game,
    LoadingScene
}

private static Scene targetScene;

public static void Load(Scene targetScene)
{
    Loader.targetScene = targetScene;

    SceneManager.LoadScene(Scene.LoadingScene.ToString());

}

public static void LoaderCallBack()
{
    SceneManager.LoadScene(targetScene.ToString());
}
}
