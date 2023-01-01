
using UnityEngine;
using UnityEngine.Events;

namespace TerraiJason
{
    /// <summary>
    /// ���ʨt��:�������a�O�_�i�J�åB���椬�ʦ欰
    /// </summary>
public class InteractableSystem : MonoBehaviour
{
        [SerializeField, Header("��ܸ��")]
        private DialogueData dataDialogue;
        [SerializeField, Header("��ܵ����᪺�ƥ�")]
        private UnityEvent onDialogueFinish;//�ƥ�

        [SerializeField, Header("�ҰʹD��")]
        private GameObject propActive;
        [SerializeField, Header("�Ұʫ᪺��ܸ��")]
        private DialogueData dataDialogueActive;
        [SerializeField, Header("�Ұʫ��ܵ����᪺�ƥ�")]
        private UnityEvent onDialogueFinishAfterActive;

        private string nameTarget = "PlayerCapsule";
        private DialogueSystem dialogueSystem;

        private void Awake()
        {
            dialogueSystem = GameObject.Find("��ܨt�Υεe��").GetComponent<DialogueSystem>();
        }


        //3D ���� �A��
        //��ӸI�����󥲶��䤤�@�ӤĿ� Is Trigger
        //�I���}�l

        private void OnTriggerEnter(Collider other)
        {
            //�p�G�I������W�٥]�tPlayerCapsule �N����{}
            if (other.name.Contains(nameTarget))
            {
//�I�쪫����ܸӪ���W��
            print(other.name);

                //�p�G���ݭn�ҰʹD�� �Ϊ� �ҰʹD��O��ܪ� �N����Ĥ@�q���
                if (propActive == null || propActive.activeInHierarchy)
                {
                    dialogueSystem.StartDialogue(dataDialogue, onDialogueFinish);
                }

                else
                {
                    dialogueSystem.StartDialogue(dataDialogueActive, onDialogueFinishAfterActive);
                }
                
            }
            
        }

        //�I������
        private void OnTriggerExit(Collider other)
        {
            
        }

        //�I������
        private void OnTriggerStay(Collider other)
        {
            
        }

        ///���ê���
        public void HiddenObject()
        {
            gameObject.SetActive(false);
        }
    }
}

