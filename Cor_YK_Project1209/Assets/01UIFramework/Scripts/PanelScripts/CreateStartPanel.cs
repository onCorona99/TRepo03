using UnityEngine;
/// <summary>
/// ������ʼ���� ��StartScene�� �ѽ���
/// ��Ϊ�ʼ��UIFramework���Խű�
/// </summary>
public class CreateStartPanel : MonoBehaviour
{
    void Start()
    {
        PanelStack.Instance.Push(new StartPanel());
    }
}