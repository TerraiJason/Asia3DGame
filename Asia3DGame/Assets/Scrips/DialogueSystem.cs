using TMPro;
using UnityEngine;
using System.Collections;
namespace TerraiJason
{
    /// <summary>
    /// 對話系統
    /// </summary>
public class DialogueSystem : MonoBehaviour
{
        //快捷鍵:Ctrl + k + s
        #region 資料區域
        [SerializeField, Header("對話間隔"), Range(0, 0.5f)]
        private float dialogueIntervalTime = 0.1f;
        [SerializeField, Header("開頭對話")]
        private DialogueData dialogueOpening;

        private WaitForSeconds dialogueInterval => new WaitForSeconds(dialogueIntervalTime);

        private CanvasGroup groupDialogue;
        private TextMeshProUGUI textName;
        private TextMeshProUGUI textContent;
        private GameObject goTriangle;
        #endregion

        #region 事件
        private void Awake()
        {
            groupDialogue = GameObject.Find("對話系統用畫布").GetComponent<CanvasGroup>();
            textName = GameObject.Find("對話者名稱").GetComponent<TextMeshProUGUI>();
            textContent = GameObject.Find("對話內容").GetComponent<TextMeshProUGUI>();
            goTriangle = GameObject.Find("完成圖示");
            goTriangle.SetActive(false);

            StartCoroutine(FadeGroup());
            StartCoroutine(TypeEffect());
        } 
        #endregion

        /// <summary>
        /// 淡入淡出的群組物件
        /// </summary>
        private IEnumerator FadeGroup()
        {
            for (int i = 0; i <10; i++)
            {
                groupDialogue.alpha += 0.1f;
                yield return new WaitForSeconds(0.04f);
                   
            }
        }

        private IEnumerator TypeEffect()
        {
            //處理說話者名稱
            textName.text = dialogueOpening.dialogueName;
            textContent.text = "";

            //下方的dialogueContents[0]中的0表示第幾段對話
            string dialogue = dialogueOpening.dialogueContents[0];

            for (int i = 0; i < dialogue.Length; i++)
            {
                textContent.text += dialogue[i];
                yield return dialogueInterval;
            }

            goTriangle.SetActive(true);
        }
    }

}

