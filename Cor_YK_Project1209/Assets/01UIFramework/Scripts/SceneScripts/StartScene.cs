using UnityEngine.SceneManagement;

public class StartScene : SceneBase
{
    public override void OnEnter()
    {
        if (SceneManager.GetActiveScene().name != PathManager.StartScene)
        {
            SceneManager.LoadScene(PathManager.StartScene);
            SceneManager.sceneLoaded += SceneLoaded;
        }
        else PanelStack.Instance.Push(new StartPanel());
    }

    public override void OnExit()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
    }

    /// <summary>
    /// ����������Ϻ�ִ�еķ���
    /// </summary>
    private void SceneLoaded(Scene scene, LoadSceneMode load)
    {
        PanelStack.Instance.Push(new StartPanel());
    }
}