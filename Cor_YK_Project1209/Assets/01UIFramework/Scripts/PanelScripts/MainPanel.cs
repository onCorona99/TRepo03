using System;
using UnityEngine;
using UnityEngine.UI;
//using XLua;

public class MainPanel : BasePanel
{
    public MainPanel() : base(new PanelType(PathManager.MainPanel)) { }

    public class Controls
    {
        public Button Exit;
        public Button DoBearPlank;
        public Button DoBackStretch;
        public Button DoBelly;

        public Button BtnOpenShopPanelLua;
    }

    public Controls m_ctl;

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void Serializable()
    {
        GameUtility.FindControls(PanelManager.Instance.panelDict[PanelStack.Instance.stack.Peek().PanelType], ref m_ctl);
    }
    public override void InitListener()
    {
        UIEventTriggerListener.Get(m_ctl.Exit.gameObject).OnClick = OnExitToStartScene;
        UIEventTriggerListener.Get(m_ctl.DoBearPlank.gameObject).OnClick = DoBearPlank;
        UIEventTriggerListener.Get(m_ctl.DoBackStretch.gameObject).OnClick = DoBackStretch;
        UIEventTriggerListener.Get(m_ctl.DoBelly.gameObject).OnClick = DoBelly;

        //UIEventTriggerListener.Get(m_ctl.BtnOpenShopPanelLua.gameObject).OnClick = OpenShopPanelByLua;
    }

    //private void OpenShopPanelByLua(GameObject go)
    //{
    //    //PanelStack.Instance.Push(new ShopPanel());
    //    Debug.Log("load Resources/OpenShop.lua.txt  [call lua][byRes]");

    //    LuaEnv env = new LuaEnv();

    //    TextAsset luaAsset = Resources.Load<TextAsset>("OpenShop.lua");
    //    if(luaAsset is null)
    //    {
    //        Debug.LogError("specified lua file doesn't exist!");
    //    }
    //    else
    //    {
    //        env.DoString(luaAsset.text);
    //    }
    //}

    /// <summary>
    /// 返回开始场景
    /// </summary>
    private void OnExitToStartScene(GameObject go)
    {
        //SystemPreload.instance.sceneSystem.SetScene(new StartScene());
        //PanelStack.Instance.PopAll();
        //GameObject.Destroy(SimpleCharacterController.instance.gameObject,0.034f);
    }

    private void DoBearPlank(GameObject go)
    {
        //SimpleCharacterController.instance.DoBearPlank();
    }

    private void DoBackStretch(GameObject go)
    {
        //SimpleCharacterController.instance.DoBackStretch();
    }

    private void DoBelly(GameObject go)
    {
        //SimpleCharacterController.instance.DoBelly();
    }

    public override void OnExit()
    {
        PanelManager.Instance.DestroyPanel(this.PanelType);
    }

    public override void OnPause()
    {
        PanelExtensionTool.Instance.GetOrAddComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public override void OnResume()
    {
        PanelExtensionTool.Instance.GetOrAddComponent<CanvasGroup>().blocksRaycasts = true;
    }
}