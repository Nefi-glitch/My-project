using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader 
{

    public enum Scene
    {
        MainMenuScene,
        GameScene,
        LoadingScene,
    }







    private static Scene targetScene;



    public static void Load(Scene targertScene)
    {
        Loader.targetScene = targertScene;

        SceneManager.LoadScene(Scene.LoadingScene.ToString());

    }
    public static void LoaderCallBack()
    {

        SceneManager.LoadScene(targetScene.ToString());
    }
}
