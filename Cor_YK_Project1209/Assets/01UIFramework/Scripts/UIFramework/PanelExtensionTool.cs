using UnityEngine;

/// <summary>
/// 面板扩展工具：给当前活动面板或其子对象添加组件
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
    /// 给当前活动面板获取或者添加一个组件
    /// </summary>
    /// <typeparam name="T">组件类型</typeparam>
    /// <returns>组件</returns>
    public T GetOrAddComponent<T>() where T : UnityEngine.Component
    {
        var go = PanelManager.Instance.panelDict[PanelStack.Instance.stack.Peek().PanelType];
        if (go.GetComponent<T>() == null)
            go.AddComponent<T>();
        return go.GetComponent<T>();
    }

    /// <summary>
    /// 根据名称，获取指定子对象上的组件，如果没有，则为其添加
    /// </summary>
    /// <param name="name">子对象的名称</param>
    /// <typeparam name="T">组件类型</typeparam>
    /// <returns>组件</returns>
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
    /// 根据名称查找顶层面板上的子对象：比如按钮
    /// </summary>
    /// <param name="name">子对象名称</param>
    public GameObject FindChildGameObject(string name)
    {
        //存储顶层面板的子对象的全部组件的Transform属性
        Transform[] trans = PanelManager.Instance.panelDict[PanelStack.Instance.stack.Peek().PanelType].GetComponentsInChildren<Transform>();

        foreach (Transform item in trans)
        {
            //在transform属性数组中，找到指定名称的子对象
            if (item.name == name)
            {
                return item.gameObject;
            }
        }

        Debug.Log("找不到子对象");
        return null;
    }
}