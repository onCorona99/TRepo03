using UnityEngine;

public class SystemPreload : MonoBehaviour
{
    public static SystemPreload instance { get; private set; }

    public SceneSystem sceneSystem { get; private set; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        sceneSystem = new SceneSystem();

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        sceneSystem.SetScene(new StartScene());
    }
}