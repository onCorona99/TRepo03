using UnityEngine;

/// <summary>
/// �����չ���ߣ�����ǰ��������Ӷ���������
/// </summary>
public class PanelExtensionTool
{
    protected static PanelExtensionTool instance = null;

    public static PanelExtensionTool Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new PanelExtensionTool();
            }
            return instance;
        }
    }

    /// <summary>
    /// ����ǰ�����ȡ�������һ�����
    /// </summary>
    /// <typeparam name="T">�������</typeparam>
    /// <returns>���</returns>
    public T GetOrAddComponent<T>() where T : UnityEngine.Component
    {
        var go = PanelManager.Instance.panelDict[PanelStack.Instance.stack.Peek().PanelType];
        if (go.GetComponent<T>() == null)
            go.AddComponent<T>();
        return go.GetComponent<T>();
    }

    /// <summary>
    /// �������ƣ���ȡָ���Ӷ����ϵ���������û�У���Ϊ�����
    /// </summary>
    /// <param name="name">�Ӷ��������</param>
    /// <typeparam name="T">�������</typeparam>
    /// <returns>���</returns>
    public T GetOrAddComponentInChildren<T>(string name) where T : UnityEngine.Component
    {
        GameObject child = FindChildGameObject(name);
        if (child)
        {
            if (child.GetComponent<T>() == null)
                child.AddComponent<T>();
            return child.GetComponent<T>();
        }
        return null;
    }

    /// <summary>
    /// �������Ʋ��Ҷ�������ϵ��Ӷ��󣺱��簴ť
    /// </summary>
    /// <param name="name">�Ӷ�������</param>
    public GameObject FindChildGameObject(string name)
    {
        //�洢���������Ӷ����ȫ�������Transform����
        Transform[] trans = PanelManager.Instance.panelDict[PanelStack.Instance.stack.Peek().PanelType].GetComponentsInChildren<Transform>();

        foreach (Transform item in trans)
        {
            //��transform���������У��ҵ�ָ�����Ƶ��Ӷ���
            if (item.name == name)
            {
                return item.gameObject;
            }
        }

        Debug.Log("�Ҳ����Ӷ���");
        return null;
    }
}