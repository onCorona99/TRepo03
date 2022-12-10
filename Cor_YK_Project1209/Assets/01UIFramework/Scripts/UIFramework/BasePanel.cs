public class BasePanel
{
    public PanelType PanelType { get; private set; }

    public BasePanel(PanelType panelType)
    {
        PanelType = panelType;
    }

    public virtual void Serializable() 
    {

    }

    public virtual void InitListener() { }
    /// <summary>
    /// OnEnterʱ ����ջ�� ִ��Serializable��InitListener
    /// </summary>
    public virtual void OnEnter() 
    {
        Serializable();
        InitListener();
    }

    public virtual void OnPause() { }

    public virtual void OnResume() { }

    public virtual void OnExit() { }
}