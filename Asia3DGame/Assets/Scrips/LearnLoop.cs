
using UnityEngine;
namespace TerraiJason
{

    /// <summary>
    /// �{�Ѱj��:���ư���{��
    /// for�Bwhile�Bdo while�Bforeach
    /// </summary>
public class LearnLoop : MonoBehaviour
{
        private void Awake()
        {
            //for �j��y�k:
            //for (��l�� ; ���L�� ���� ; �j�鵲������ϰ�){ �{���϶� }
            for (int i = 0; i < 10; i++)
            {
                print("for �j�餺�e :" + i);
            }

            //number�h�O�ۭq�W�١Ai�i�H�h�Ψ�L�W�ٴ��N
            for (int number = 0; number < 5; number++)
            {
                print("�j��:" + number);
            }
        }
    }

}

