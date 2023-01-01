using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace TerraiJason
{
    /// <summary>
    /// ��ܨt��
    /// </summary>
public class DialogueSystem : MonoBehaviour
{
        //�ֱ���:Ctrl + k + s
        #region ��ưϰ�
        [SerializeField, Header("��ܶ��j"), Range(0, 0.5f)]
        private float dialogueIntervalTime = 0.1f;
        [SerializeField, Header("�}�Y���")]
        private DialogueData dialogueOpening;
        [SerializeField, Header("��ܫ���")]
        private KeyCode dialogueKey = KeyCode.E;

        private WaitForSeconds dialogueInterval => new WaitForSeconds(dialogueIntervalTime);

        private CanvasGroup groupDialogue;
        private TextMeshProUGUI textName;
        private TextMeshProUGUI textContent;
        private GameObject goTriangle;
        #endregion

        private PlayerInput playerInput;
        private UnityEvent onDialogueFinish;
        #region �ƥ�
        private void Awake()
        {
            groupDialogue = GameObject.Find("��ܨt�Υεe��").GetComponent<CanvasGroup>();
            textName = GameObject.Find("��ܪ̦W��").GetComponent<TextMeshProUGUI>();
            textContent = GameObject.Find("��ܤ��e").GetComponent<TextMeshProUGUI>();
            goTriangle = GameObject.Find("�����ϥ�");
            goTriangle.SetActive(false);

            playerInput = GameObject.Find("PlayerCapsule").GetComponent<PlayerInput>();

            StartDialogue(dialogueOpening);

   
        } 
        #endregion

        /// <summary>
        /// �}�l���
        /// </summary>
        /// <param name="data">�n���檺��ܸ��</param>
        /// <param name="_onDialogueFinish">��ܵ����᪺�ƥ�A�i�H�ŭ�</param>

        public void StartDialogue(DialogueData data, UnityEvent _onDialogueFinish = null)
        {

            //enabled �O���Ӫ��󪺱ҰʻP�_
            //��ܮɡA����a������
            playerInput.enabled = false; //�������a��J����
            StartCoroutine(FadeGroup());
            StartCoroutine(TypeEffect(data));
            onDialogueFinish = _onDialogueFinish;
        }

        /// <summary>
        /// �H�J�H�X���s�ժ���
        /// </summary>
        private IEnumerator FadeGroup(bool fadeIn = true)
        {
            ///�T���B��l ? :
            ///�y�k :
            ///���L�� ? ���L�Ȭ� true : ���L�Ȭ� false;
            ///true ? 1 : 10;���G��1
            ///false ? 1 : 10;���G��10
            ///�U�謰�@�ӨҤl
            float increase = fadeIn ? +0.1f : -0.1f;

            for (int i = 0; i <10; i++)
            {
                groupDialogue.alpha +=increase;
                yield return new WaitForSeconds(0.04f);
                   
            }
        }

        private IEnumerator TypeEffect(DialogueData data)
        {
            //�B�z���ܪ̦W��
            textName.text = data.dialogueName;

            for (int j = 0; j < data.dialogueContents.Length; j++)
            {
                textContent.text = "";

                //�B�z�T���ιϥܡA�Ϩ�@�}�l�O���ê��A
                goTriangle.SetActive(false);

                //�U�誺dialogueContents[0]����0��ܲĴX�q���
                string dialogue = data.dialogueContents[j];

            for (int i = 0; i < dialogue.Length; i++)
            {
                textContent.text += dialogue[i];
                yield return dialogueInterval;
            }

            goTriangle.SetActive(true);

            //�p�G���a�٨S���U���w����A�h����
            while(!Input.GetKeyDown(dialogueKey))
            {
                yield return null;
            }

            print("<color=#993300>���a���U����!</color>");
            }

            //��ܵ������ɭԡA�H�X�o�ӹ�ܮ�
            StartCoroutine(FadeGroup(false));

            //��ܵ�����A���ꪱ�a������
            playerInput.enabled = true; //�}�Ҫ��a��J����

            //?. ��onDialogueFinish �S���ȮɴN������
            onDialogueFinish?.Invoke(); //��ܵ����ƥ�.�I�s() ;
            

            

        }
    }

}

