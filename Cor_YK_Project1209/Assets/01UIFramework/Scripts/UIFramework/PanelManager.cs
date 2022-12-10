using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����������������������壬���洢�򿪵�������Ϣ
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
    /// ���ֵ�洢���д򿪵���壬ÿһ��������Ӧһ�����
    /// </summary>
    public Dictionary<PanelType, GameObject> panelDict;

    /// <summary>
    /// ���캯������ʼ���ֵ�
    /// </summary>
    public PanelManager()
    {
        panelDict = new Dictionary<PanelType, GameObject>();
    }

    /// <summary>
    /// Instantiateһ����� �������ֵ�
    /// </summary>
    /// <param name="type">UI����</param>
    /// <returns></returns>
    public GameObject ShowPanel(PanelType type)
    {
        //������ָ��Ϊ���ĸ�����
        GameObject parent = GameObject.Find("Canvas");
        if (!parent)
        {
            UnityEngine.Debug.Log("Error:����������");
            return null;
        }
        //����ֵ�����ָ����������Ϣ���򷵻�������Ķ���
        if (panelDict.ContainsKey(type))
            return panelDict[type];
        //��ָ��������¡��������
        GameObject panel = GameObject.Instantiate(Resources.Load<GameObject>(type.Path), parent.transform);
        //�趨�����������
        panel.name = type.Name;
        //�����ֵ�
        panelDict.Add(type, panel);
        return panel;
    }

    /// <summary>
    /// �ر�һ�����
    /// </summary>
    public void DestroyPanel(PanelType type)
    {
        if (panelDict.ContainsKey(type))
        {
            //����ָ�������
            Object.Destroy(panelDict[type]);
            //���ֵ��Ƴ������ļ�ֵ��
            panelDict.Remove(type);
        }
    }
}