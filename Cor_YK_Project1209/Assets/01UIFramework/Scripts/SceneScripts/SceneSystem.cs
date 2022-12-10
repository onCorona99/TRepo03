public class SceneSystem
{
    private SceneBase sceneBase;

    public void SetScene(SceneBase scene)
    {
        sceneBase?.OnExit();
        sceneBase = scene;
        sceneBase?.OnEnter();
    }
}