using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using ZZH.Core;

namespace System
{
    public class PatrolSystem
    {
        private static PatrolSystem _instance = new ();
        public static PatrolSystem Instance => _instance ??= new PatrolSystem();

        public List<int> patrolDays; // 会巡逻的日期

        private PatrolSystem()
        {
            var intervals = new List<int>() { 0, 1, 2, 2, 3 };
            intervals.Shuffle();
            
            patrolDays = new List<int>();
            var patrolDay = 1;
            intervals.ForEach(j =>
            {
                patrolDay += j;
                patrolDays.Add(patrolDay);
                patrolDay++;
            });
        }

        public void OnCharacterGoOutside(RoleObject role)
        {
            var day = DaySystem.Instance;
            Debug.Log(string.Join(",", patrolDays));
            Debug.Log(day.currentDay);
            if (patrolDays.Any(dayNumber => day.currentDay == dayNumber))
            {
                role.currentHp = 0;
            }
        }
    }
}