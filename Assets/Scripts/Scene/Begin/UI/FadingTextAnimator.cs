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
        
        private void FixedUpdate()
        {
            dialogue.isShow = true;
            
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

            dialogue.textMeshPro.color = color;
            tickExisted++;
        }

    }
}