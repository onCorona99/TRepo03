using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : BasePanel
{
    public ShopPanel() : base(new PanelType(PathManager.ShopPanel)) { }

    public class Controls
    {
        public Button Back;
        
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
        UIEventTriggerListener.Get(m_ctl.Back.gameObject).OnClick = OnBackToGame;
     
    }

    /// <summary>
    /// Àë¿ªÉÌµêÒ³Ãæ
    /// </summary>
    private void OnBackToGame(GameObject go)
    {
        PanelStack.Instance.Pop();
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