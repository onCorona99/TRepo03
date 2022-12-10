using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���֮ջ�����ڹ���������Ӧ˳��
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
    /// �洢����ջ
    /// </summary>
    public Stack<BasePanel> stack;

    //����������
    private BasePanel panel;

    /// <summary>
    /// ��ʼ�����֮ջ
    /// </summary>
    public PanelStack()
    {
        stack = new Stack<BasePanel>();
    }

    /// <summary>
    /// �����ʱ�������ջ
    /// </summary>
    /// <param name="nextPanel"></param>
    public void Push(BasePanel nextPanel)
    {
        //��������������ʾ
        if (stack.Count > 0)
        {
            //ȡջ��
            panel = stack.Peek();
            //��ͣ��һ�����
            panel.OnPause();
        }
        //�������ջ
        stack.Push(nextPanel);
        //��ȡһ�����
        GameObject panelToShow = PanelManager.Instance.ShowPanel(nextPanel.PanelType);

        //������ʱҪִ�е�����
        nextPanel.OnEnter();
    }

    /// <summary>
    /// �ر����ʱ������ջ������ջ������壬�ٻָ���ջ�������
    /// </summary>
    public void Pop()
    {
        if (stack.Count > 0)
        {
            stack.Pop().OnExit();

            //ջ��������˳�
            //stack.Peek().OnExit();
            //����ջ
            //stack.Pop();
        }
        //�ָ��²����
        if (stack.Count > 0)
            stack.Peek().OnResume();
    }

    /// <summary>
    /// �ر�������岢ִ�����˳�����
    /// </summary>
    public void PopAll()
    {
        while (stack.Count > 0)
            stack.Pop().OnExit();
    }
}