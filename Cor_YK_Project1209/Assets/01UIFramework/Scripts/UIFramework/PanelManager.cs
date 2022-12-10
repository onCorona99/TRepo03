using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 面板管理器：创建或销毁面板，并存储打开的面板的信息
/// </summary>
public class PanelManager
{
    protected static PanelManager instance = null;

    public static PanelManager Instance
    {
        get
        {
            if (null == instance)
            {
                instance = new PanelManager();
            }
            return instance;
        }
    }
    /// <summary>
    /// 用字典存储所有打开的面板，每一个面板类对应一个面板
    /// </summary>
    public Dictionary<PanelType, GameObject> panelDict;

    /// <summary>
    /// 构造函数：初始化字典
    /// </summary>
    public PanelManager()
    {
        panelDict = new Dictionary<PanelType, GameObject>();
    }

    /// <summary>
    /// Instantiate一个面板 并加入字典
    /// </summary>
    /// <param name="type">UI类型</param>
    /// <returns></returns>
    public GameObject ShowPanel(PanelType type)
    {
        //将画布指定为面板的父对象
        GameObject parent = GameObject.Find("Canvas");
        if (!parent)
        {
            UnityEngine.Debug.Log("Error:画布不存在");
            return null;
        }
        //如果字典中有指定的面板的信息，则返回这个面板的对象
        if (panelDict.ContainsKey(type))
            return panelDict[type];
        //将指定的面板克隆到画布上
        GameObject panel = GameObject.Instantiate(Resources.Load<GameObject>(type.Path), parent.transform);
        //设定面板对象的名字
        panel.name = type.Name;
        //加入字典
        panelDict.Add(type, panel);
        return panel;
    }

    /// <summary>
    /// 关闭一个面板
    /// </summary>
    public void DestroyPanel(PanelType type)
    {
        if (panelDict.ContainsKey(type))
        {
            //销毁指定的面板
            Object.Destroy(panelDict[type]);
            //从字典移除该面板的键值对
            panelDict.Remove(type);
        }
    }
}