using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// ������ ���������-����������, ������� ������ ���� �������� ��� ����
public class ScrollingScript : MonoBehaviour
{
    // �������� ���������
    public Vector2 speed = new Vector2(10, 10);

    // ����������� ��������
    public Vector2 direction = new Vector2(-1, 0);

    // �������� ������ ���� ��������� � ������
    public bool isLinkedToCamera = false;

    // 1 � ����������� ���
    public bool isLooping = false;

    // 2 � ������ ����� � ����������
    private List<Transform> backgroundPart;

    // 3 - �������� ���� �������))
    void Start()
    {
        // ������ ��� ������������ ����
        if (isLooping)
        {
            // ������������� ���� ����� ���� � ����������
            backgroundPart = new List<Transform>();

            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);

                // �������� ������ ������� �����
                if (child.GetComponent<Renderer>() != null)
                {
                    backgroundPart.Add(child);
                }
            }

            // ���������� �� �������.
            // ����������: �������� ����� ����� �������.
            // �� ������ �������� ��������� ������� ��� ���������
            // ������ ����������� ���������.
            backgroundPart = backgroundPart.OrderBy(
              t => t.position.x
            ).ToList();
        }
    }

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

        // 4 - Loop
        if (isLooping)
        {
            // ��������� ������� �������.
            // ������ ���������� ����� (������� �� ��� X) �������.
            Transform firstChild = backgroundPart.FirstOrDefault();

            if (firstChild != null)
            {
                // ���������, ��������� �� ������� (��������) ����� �������.
                // ������ ����� �� ��������� �������, �.�. ����� IsVisibleFrom
                // ������� ������� ��������� � �����
                if (firstChild.position.x < Camera.main.transform.position.x)
                {
                    // ���� ������� ��� ����� �� ������,
                    // �� ���������, ������� �� �� ������� �����, ����� ������������ ���
                    // ��������.
                    if (firstChild.GetComponent<Renderer>().isVisible == false)
                    {
                        // �������� ��������� ������� �������.
                        Transform lastChild = backgroundPart.LastOrDefault();
                        Vector3 lastPosition = lastChild.transform.position;
                        Vector3 lastSize = (lastChild.GetComponent<Renderer>().bounds.max - lastChild.GetComponent<Renderer>().bounds.min);

                        // ����������� �������� ������������ ������ ���, ����� �� ������������ �����
                        // ���������� �������
                        // ����������: ���� �������� ������ ��� ��������������� ����������.
                        firstChild.position = new Vector3(lastPosition.x + lastSize.x, firstChild.position.y, firstChild.position.z);

                        // ��������� �������� ������������ ������
                        // � ����� ������ backgroundPart.
                        backgroundPart.Remove(firstChild);
                        backgroundPart.Add(firstChild);
                    }
                }
            }
        }
    }
}

