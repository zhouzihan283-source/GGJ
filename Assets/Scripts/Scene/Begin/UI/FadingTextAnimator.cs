using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Scene.Begin.UI
{
    public class FadingTextAnimator: MonoBehaviour
    {
        public int tickExisted;
        public int fadeInTick = 50;
        public int sustainTick = 500;
        public int fadeOutTick = 50;
        public bool shouldStart;
        private const float SecondsPerTick = 0.02f;

        public DialoguePanel dialogue;

        private void Start()
        {
            dialogue.isShow = true;
        }

        private void FixedUpdate()
        {
            var unit = 1F / fadeInTick;
            var color = dialogue.textMeshPro.color;

            if (!shouldStart)
            {
                color.a = 0;
                dialogue.textMeshPro.color = color;
                return;
            }
            
            if (tickExisted < fadeInTick) color.a += unit;
            if (tickExisted >= sustainTick) color.a -= unit;
            
            // 如果alpha通道为0，则停止动画，准备让下一段文本进行调用
            if (color.a < 1e-5)
            {
                color.a = 0;
                dialogue.textMeshPro.color = color;
                shouldStart = false;
                return;
            }

            dialogue.textMeshPro.color = color;
            tickExisted++;
        }
    }
}