/// <summary>
/// ����������Ϣ
/// </summary>
public class PanelType
{
    /// <summary>
    /// ��������
    /// </summary>
    public string Name;

    /// <summary>
    /// ���Ĵ洢·��
    /// </summary>
    public string Path;

    public PanelType(string path)
    {
        Path = path;
        //��ȡб�ܺ��ȫ���ַ�
        Name = path.Substring(path.LastIndexOf('/') + 1);
    }
}