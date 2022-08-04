using UnityEngine;

/// ������ ���������-����������, ������� ����� ��������� ��� ����
public class ScrollingScript : MonoBehaviour
{
    // �������� ���������
    public Vector2 speed = new Vector2(2, 2);

    // ����������� ��������
    public Vector2 direction = new Vector2(-1, 0);

    // �������� ������ ���� ��������� � ������
    public bool isLinkedToCamera = false;

    void Update()
    {
        // �����������
        Vector3 movement = new Vector3(
          speed.x * direction.x,
          speed.y * direction.y,
          0);

        movement *= Time.deltaTime;
        transform.Translate(movement);

        // ����������� ������
        if (isLinkedToCamera)
        {
            Camera.main.transform.Translate(movement);
        }
    }
}