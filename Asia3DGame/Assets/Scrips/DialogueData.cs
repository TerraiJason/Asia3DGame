
using Cinemachine;
using UnityEngine;
namespace TerraiJason
{
    /// <summary>
    /// ��ܸ��
    /// </summary>
    [CreateAssetMenu(menuName = "Jason/DialogueData" , fileName = "New DialogueData")]
public class DialogueData : ScriptableObject
{
        [Header("��ܪ̦W��")]
        public string dialogueName;

        [Header("��ܪ̤��e"), TextArea(2, 10)]
        public string[] dialogueContents;
}

}
