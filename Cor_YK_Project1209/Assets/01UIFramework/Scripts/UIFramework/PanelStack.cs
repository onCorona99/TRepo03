using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 面板之栈：用于管理面板的响应顺序
/// </summary>
public class PanelStack
{
    protected static PanelStack instance = null;

    public static PanelStack Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new PanelStack();
            }
            return instance;
        }
    }

    /// <summary>
    /// 存储面板的栈
    /// </summary>
    public Stack<BasePanel> stack;

    //面板基类引用
    private BasePanel panel;

    /// <summary>
    /// 初始化面板之栈
    /// </summary>
    public PanelStack()
    {
        stack = new Stack<BasePanel>();
    }

    /// <summary>
    /// 打开面板时将面板入栈
    /// </summary>
    /// <param name="nextPanel"></param>
    public void Push(BasePanel nextPanel)
    {
        //如果还有面板在显示
        if (stack.Count > 0)
        {
            //取栈顶
            panel = stack.Peek();
            //暂停上一个面板
            panel.OnPause();
        }
        //新面板入栈
        stack.Push(nextPanel);
        //获取一个面板
        GameObject panelToShow = PanelManager.Instance.ShowPanel(nextPanel.PanelType);

        //面板进入时要执行的任务
        nextPanel.OnEnter();
    }

    /// <summary>
    /// 关闭面板时将面板出栈：弹出栈顶的面板，再恢复新栈顶的面板
    /// </summary>
    public void Pop()
    {
        if (stack.Count > 0)
        {
            stack.Pop().OnExit();

            //栈顶的面板退出
            //stack.Peek().OnExit();
            //面板出栈
            //stack.Pop();
        }
        //恢复下层面板
        if (stack.Count > 0)
            stack.Peek().OnResume();
    }

    /// <summary>
    /// 关闭所有面板并执行其退出函数
    /// </summary>
    public void PopAll()
    {
        while (stack.Count > 0)
            stack.Pop().OnExit();
    }
}