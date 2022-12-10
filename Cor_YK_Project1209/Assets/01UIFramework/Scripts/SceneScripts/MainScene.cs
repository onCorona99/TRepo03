using UnityEngine.SceneManagement;

public class MainScene : SceneBase
{
    public override void OnEnter()
    {
        if (SceneManager.GetActiveScene().name != PathManager.MainScene)
        {
            SceneManager.LoadScene(PathManager.MainScene);
            SceneManager.sceneLoaded += SceneLoaded;
        }
        else PanelStack.Instance.Push(new MainPanel());
    }

    public override void OnExit()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
    }

    void SceneLoaded(Scene scene, LoadSceneMode load)
    {
        PanelStack.Instance.Push(new MainPanel());
    }
}