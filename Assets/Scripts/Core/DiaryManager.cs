using System;
using System.Collections.Generic;
using System.Text;
using Scene.Begin.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Core
{
    /// <summary>
    /// 新的一天 + 进食? + (偷听 | 杀害 | 探索)?
    /// </summary>
    public class DiaryManager: MonoBehaviour
    {
        public TMP_Text textMeshPro;
        public int currentPage;

        public Button prevPage;
        public Button nextPage;

        private DialoguePanel _dialogue;
        private FadingTextAnimator _fading;
        private DaySystem _day;

        public Dictionary<int, string> pages;
        public int eatCount;
        
        public int hearResult;
        public int outsideResult;
        public int ending;

        private void Start()
        {
            _day = DaySystem.Instance;

            prevPage.onClick.AddListener(() => currentPage = currentPage == 0 ? 0 : currentPage--);
            nextPage.onClick.AddListener(() =>
            {
                var nextPageIndex = currentPage + 1;
                if (pages.TryGetValue(currentPage, out var story))
                {
                    currentPage = nextPageIndex;
                }
            });
        }

        private void Update()
        {
            textMeshPro.text = pages[currentPage];
        }

        public void SetContent(string content)
        {
            
        }
        
    }
}