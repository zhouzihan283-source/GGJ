using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ZZH.Core
{
    /// <summary>
    /// 集合拓展方法
    /// </summary>
    public static class CollectionExtension
    {
        /// <summary>
        /// 是否为null或空集合
        /// </summary>
        public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
        {
            return collection is not { Count : > 0 };
        }

        /// <summary>
        /// 是否为空集合
        /// </summary>
        public static bool IsEmpty<T>(this ICollection<T> collection)
        {
            return collection.Count == 0;
        }

        /// <summary>
        /// 通过某个元素排序
        /// </summary>
        public static void Sort<T, K>(this List<T> list, Func<T, K> getCompare) where K : IComparable<K>
        {
            list.Sort((left, right) => getCompare(left).CompareTo(getCompare(right)));
        }

        /// <summary>
        /// 检查是否存在，若不存在，则添加
        /// </summary>
        public static bool AddIfNotExist<T>(this ICollection<T> collection, T t)
        {
            if (collection.Contains(t) == false)
            {
                collection.Add(t);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 检查是否存在，若不存在，则添加
        /// </summary>
        public static bool AddIfNotExist<TKey, TValue>(this IDictionary<TKey, TValue> collection, TKey key, TValue value)
        {
            if (collection.ContainsKey(key) == false)
            {
                collection.Add(key, value);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 无分配FindAll，需要自己传入集合
        /// </summary>
        public static void FindAllNoAlloc<T>(this IList<T> list, Predicate<T> match,IList<T> resultList)
        {
            if (match == null)
            {
                throw new NullReferenceException("match");
            }
            if (resultList == null)
            {
                throw new NullReferenceException("result");
            }
            resultList.Clear();

            int count = list.Count;
            T t;
            for (int i = 0; i < count; i++)
            {
                t = list[i];
                if (match(t))
                {
                    resultList.Add(t);
                }
            }
        }

        /// <summary>
        /// 查询是否存在指定条件对象
        /// </summary>
        public static bool TryFind<T>(this IList<T> list, Predicate<T> match, out T result)
        {
            if (match == null)
            {
                throw new NullReferenceException("match");
            }

            int count = list.Count;
            T t;
            for (int i = 0; i < count; i++)
            {
                t = list[i];
                if (match(t))
                {
                    result = t;
                    return true;
                }
            }
            result = default;
            return false;
        }

        /// <summary>
        /// 查询是否存在指定条件对象
        /// </summary>
        public static bool TryFindAll<T>(this IList<T> list, Predicate<T> match, out List<T> resultList)
        {
            if (match == null)
            {
                throw new NullReferenceException("match");
            }

            int count = list.Count;
            T t;
            resultList = new List<T>();
            for (int i = 0; i < count; i++)
            {
                t = list[i];
                if (match(t))
                {
                    resultList.Add(t);
                }
            }
            if (resultList.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 尝试移除所有符合条件的对象，并返回该列表
        /// </summary>
        public static bool TryRemoveAll<T>(this List<T> list, Predicate<T> match, out List<T> result)
        {
            if (list == null)
            {
                throw new NullReferenceException(nameof(list));
            }
            List<T> __removeList = new List<T>();
            if (list.IsEmpty() == false)
            {
                T __t;
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    __t = list[i];
                    if (match(__t))
                    {
                        list.RemoveAt(i);
                        __removeList.Add(__t);
                    }
                }
            }
            result = __removeList;
            return __removeList.Count > 0;
        }

        /// <summary>
        /// 尝试找到索引
        /// </summary>
        public static bool TryFindIndex<T>(this IList<T> list, Predicate<T> match, out int result)
        {
            if (list == null)
            {
                throw new NullReferenceException();
            }
            result = -1;
            for (int i = 0; i < list.Count; i++)
            {
                if (match(list[i]))
                {
                    result = i;
                    break;
                }
            }
            return result >= 0;
        }

        /// <summary>
        /// 尝试移除
        /// </summary>
        public static bool TryRemove<T>(this List<T> list, Predicate<T> match, out T t)
        {
            if (list == null)
            {
                throw new System.NullReferenceException();
            }
            if (list.TryFindIndex(match, out int __index))
            {
                t = list[__index];
                list.RemoveAt(__index);
                return true;
            }
            t = default;
            return false;
        }

        /// <summary>
        /// 尝试移除
        /// </summary>
        public static bool TryRemove<T>(this List<T> list, Predicate<T> match)
        {
            if (!list.IsNullOrEmpty())
            {
                int __index = list.FindIndex(match);
                if (__index >= 0)
                {
                    list.RemoveAt(__index);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 尝试更新
        /// </summary>
        public static bool TryUpdate<T>(this List<T> list, Predicate<T> match, T newData)
        {
            if (list.TryFindIndex(match, out int index))
            {
                list[index] = newData;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 更新列表，没有则添加，符合删除条件则删除
        /// </summary>
        public static void Update<T, TSelector>(this List<T> list,List<T> newList ,Func<T,TSelector> selector, Predicate<T> deleteMatch = null)
        {
            if (newList.IsNullOrEmpty())
            {
                return;
            }
            for (int i = 0; i < newList.Count; i++)
            {
                Update(list, newList[i], selector, deleteMatch);
            }
        }

        /// <summary>
        /// 更新列表，没有则添加，符合删除条件则删除
        /// </summary>
        public static void Update<T, TSelector>(this List<T> list, T newData, Func<T, TSelector> selector, Predicate<T> deleteMatch = null)
        {
            if (list.TryFindIndex(n => selector(n).Equals(selector(newData)), out int index))
            {
                if (deleteMatch != null && deleteMatch(newData))
                {
                    list.RemoveAt(index);
                }
                else
                {
                    list[index] = newData;
                }
            }
            else
            {
                list.Add(newData);
            }
        }


        public static void RemoveLast<T>(this List<T> list)
        {
            if (list.IsNullOrEmpty())
            {
                throw new System.InvalidOperationException();
            }
            list.RemoveAt(list.Count - 1);
        }



        /// <summary>
        /// 洗牌
        /// </summary>
        public static void Shuffle<T>(this IList<T> list)
        {
            Random random = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        /// <summary>
        /// List格式化输出
        /// </summary>
        public static string ListToString<T>(this List<T> list)
        {
            System.Text.StringBuilder __sb = new System.Text.StringBuilder();
            foreach (T t in list)
            {
                __sb.Append(t.ToString());
                __sb.Append(",");
            }
            return __sb.ToString();
        }
        

        /// <summary>
        /// 倒序遍历
        /// </summary>
        public static List<T> ForEachReverse<T>(this List<T> selfList, Action<T> action)
        {
            if (action == null) throw new ArgumentException();

            for (var i = selfList.Count - 1; i >= 0; --i)
                action(selfList[i]);

            return selfList;
        }
        /// <summary>
        /// 倒序遍历（可获得索引)
        /// </summary>
        public static List<T> ForEachReverse<T>(this List<T> selfList, Action<T, int> action)
        {
            if (action == null) throw new ArgumentException();

            for (var i = selfList.Count - 1; i >= 0; --i)
                action(selfList[i], i);

            return selfList;
        }
        /// <summary>
        /// 遍历列表(可获得索引）
        /// </summary>
        public static void ForEach<T>(this List<T> list, Action<int, T> action)
        {
            for (var i = 0; i < list.Count; i++)
            {
                action(i, list[i]);
            }
        }

       

        /// <summary>
        /// 字典相等
        /// </summary>
        public static bool DicEquals<TKey, TValue>(this Dictionary<TKey, TValue> dict1, Dictionary<TKey, TValue> dict2)
        {
            if (dict1 == dict2) return true;
            if ((dict1 == null) || (dict2 == null)) return false;
            if (dict1.Count != dict2.Count) return false;

            EqualityComparer<TValue> __valueComparer = EqualityComparer<TValue>.Default;

            foreach (var kvp in dict1)
            {
                TValue value2;
                if (!dict2.TryGetValue(kvp.Key, out value2)) return false;
                if (!__valueComparer.Equals(kvp.Value, value2)) return false;
            }
            return true;
        }
        #region Array
        /// <summary>
        /// 遍历
        /// </summary>
        public static void ForEach<T>(this T[] array, Action<T> action)
        {
            if (array == null)
            {
                throw new NullReferenceException(nameof(array));
            }
            if (action == null)
            {
                throw new NullReferenceException(nameof(action));
            }
            int length = array.Length;
            for (int i = 0; i < length; i++)
            {
                action.Invoke(array[i]);
            }
        }
        /// <summary>
        /// 查找数组内指定条件元素
        /// </summary>
        public static T Find<T>(this T[] array, Predicate<T> match)
        {
            if (array == null)
            {
                throw new NullReferenceException(nameof(array));
            }
            if (match == null)
            {
                throw new NullReferenceException(nameof(match));
            }
            return Array.Find(array, match);
        }
        /// <summary>
        /// 查找数组内指定条件元素
        /// </summary>
        public static bool TryFind<T>(this T[] array, Predicate<T> match, out T t)
        {
            if (array == null)
            {
                throw new NullReferenceException(nameof(array));
            }
            if (match == null)
            {
                throw new NullReferenceException(nameof(match));
            }
            t = Array.Find(array, match);
            return t != null && t.Equals(default) == false;
        }
        /// <summary>
        /// 查找数组内指定条件元素Index
        /// </summary>
        public static int FindIndex<T>(this T[] array, Predicate<T> match)
        {
            if (array == null)
            {
                throw new NullReferenceException(nameof(array));
            }
            if (match == null)
            {
                throw new NullReferenceException(nameof(match));
            }
            return Array.FindIndex(array, match);
        }
        /// <summary>
        /// 返回指定元素的Index
        /// </summary>
        public static int IndexOf<T>(this T[] array, T value)
        {
            if (array == null)
            {
                throw new NullReferenceException(nameof(array));
            }
            return Array.IndexOf(array, value);
        }

        /// <summary>
        /// 检查指定元素是否存在
        /// </summary>
        public static bool Contains<T>(this T[] array, T value)
        {
            if (array == null)
            {
                throw new NullReferenceException(nameof(array));
            }
            return Array.IndexOf(array, value) >= 0;
        }

        /// <summary>
        /// 检查指定条件元素是否存在
        /// </summary>
        public static bool Exists<T>(this T[] array, Predicate<T> match)
        {
            if (array == null)
            {
                throw new NullReferenceException(nameof(array));
            }
            if (match == null)
            {
                throw new NullReferenceException(nameof(match));
            }
            int length = array.Length;
            T t;
            for (int i = 0; i < length; i++)
            {
                t = array[i];
                if (match(t))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 投影
        /// </summary>
        public static TOutput[] SSelect<TInput, TOutput>(this TInput[] array, Converter<TInput, TOutput> converter)
        {
            if (array == null)
            {
                throw new NullReferenceException(nameof(array));
            }
            if (converter == null)
            {
                throw new NullReferenceException(nameof(converter));
            }
            return Array.ConvertAll(array, converter);
        }
        /// <summary>
        /// 清理
        /// </summary>
        public static void Clear<T>(this T[] array)
        {
            if (array == null)
            {
                throw new NullReferenceException(nameof(array));
            }
            Array.Clear(array, 0, array.Length);
        }
        #endregion
        #region IList
        /// <summary>
        /// 移除并返回第一个元素
        /// </summary>
        public static T RemoveFirst<T>(this IList<T> list)
        {
            if (list.IsNullOrEmpty())
            {
                return default;
            }
            T t = list[0];
            list.RemoveAt(0);
            return t;
        }
        /// <summary>
        /// 找列表中符合条件的最小值的对象
        /// </summary>
        public static T FindMin<T, TValue>(this IList<T> list, Func<T, TValue> selector) where TValue : IComparable<TValue>
        {
            if (list.IsNullOrEmpty())
            {
                return default;
            }
            if (selector == null)
            {
                throw new NullReferenceException(nameof(selector));
            }
            //先置初值为第一项，然后从第二项开始遍历，如果找到更小的，移动指针
            T result = list[0];
            TValue resultValue = selector(result);
            T pointer;
            TValue value;
            for (int i = 1; i < list.Count; i++)
            {
                pointer = list[i];
                value = selector(pointer);
                if (value.CompareTo(resultValue) < 0)
                {
                    result = pointer;
                    resultValue = value;
                }
            }
            return result;
        }
        /// <summary>
        /// 找列表中符合条件的最大值的对象
        /// </summary>
        public static T FindMax<T, TValue>(this IList<T> list, Func<T, TValue> selector) where TValue : IComparable<TValue>
        {
            if (list.IsNullOrEmpty())
            {
                return default;
            }
            if (selector == null)
            {
                throw new NullReferenceException(nameof(selector));
            }
            //先置初值为第一项，然后从第二项开始遍历，如果找到更大的，移动指针
            T result = list[0];
            TValue resultValue = selector(result);
            T pointer;
            TValue value;
            for (int i = 1; i < list.Count; i++)
            {
                pointer = list[i];
                value = selector(pointer);
                if (value.CompareTo(resultValue) > 0)
                {
                    result = pointer;
                    resultValue = value;
                }
            }
            return result;
        }
        /// <summary>
        /// 投影
        /// </summary>
        public static List<K> SSelect<T, K>(this List<T> list, Func<T, K> convert)
        {
            if (list == null)
            {
                throw new NullReferenceException(nameof(list));
            }
            if (convert == null)
            {
                throw new NullReferenceException(nameof(convert));
            }
            int count = list.Count;
            List<K> result = new List<K>(count);
            for (var i = 0; i < list.Count; i++)
            {
                result.Add(convert.Invoke(list[i]));
            }
            return result;
        }
        /// <summary>
        /// 得到列表满足条件的项的数量
        /// </summary>
        public static int SCount<T>(this IList<T> list, Predicate<T> match)
        {
            if (list == null)
            {
                throw new NullReferenceException(nameof(list));
            }
            if (match == null)
            {
                throw new NullReferenceException(nameof(match));
            }
            int count = list.Count;
            if (count == 0)
            {
                return 0;
            }
            int result = 0;
            for (int i = 0; i < count; i++)
            {
                if (match(list[i]))
                {
                    result++;
                }
            }
            return result;
        }
        /// <summary>
        /// 元素交换
        /// </summary>
        public static void Swap<T>(this IList<T> list, ref T t1, ref T t2)
        {
            (t1, t2) = (t2, t1);
        }
        #endregion
        #region ReadOnlyCollection
        /// <summary>
        /// 只读列表Find
        /// </summary>
        public static T Find<T>(this ReadOnlyCollection<T> readonlyList, Predicate<T> match)
        {
            if (match == null)
            {
                throw new NullReferenceException("match");
            }
            int count = readonlyList.Count;
            T t;
            for (int i = 0; i < count; i++)
            {
                t = readonlyList[i];
                if (match(t))
                {
                    return t;
                }
            }
            return default;
        }

        /// <summary>
        /// 只读列表FindAll
        /// </summary>
        public static List<T> FindAll<T>(this ReadOnlyCollection<T> readonlyList, Predicate<T> match)
        {
            if (match == null)
            {
                throw new NullReferenceException("match");
            }

            List<T> list = new List<T>();
            int count = readonlyList.Count;
            T t;
            for (int i = 0; i < count; i++)
            {
                t = readonlyList[i];
                if (match(t))
                {
                    list.Add(t);
                }
            }
            return list;
        }
        #endregion
        #region LinkList
        /// <summary>
        /// 链表FindAll
        /// </summary>
        public static List<T> FindAll<T>(this LinkedList<T> linkList, Predicate<T> match)
        {
            if (match == null)
            {
                throw new NullReferenceException("match");
            }
            List<T> list = new List<T>();
            foreach (T t in linkList)
            {
                if (match(t))
                {
                    list.Add(t);
                }
            }
            return list;
        }
        #endregion
    }

}

