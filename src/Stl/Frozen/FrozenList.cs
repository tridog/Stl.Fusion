using System;
using System.Collections;
using System.Collections.Generic;

namespace Stl.Frozen
{
    public interface IFrozenList<T> : IList<T>, IFrozenCollection<T> { }

    [Serializable]
    public class FrozenList<T> : FrozenBase, IFrozenList<T>, IFrozenEnumerable<T>
    {
        protected static readonly bool AreItemsFrozen = 
            typeof(IFrozen).IsAssignableFrom(typeof(T));
        
        protected List<T> List { get; set; }
        public int Count => List.Count;
        public bool IsReadOnly => IsFrozen;

        public T this[int index] {
            get => List[index];
            set {
                this.ThrowIfFrozen();
                List[index] = value;
            }
        }

        public FrozenList() => List = new List<T>();
        public FrozenList(int capacity) => List = new List<T>(capacity);
        public FrozenList(IEnumerable<T> items) => List = new List<T>(items);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<T> GetEnumerator() => List.GetEnumerator();
        public bool Contains(T item) => List.Contains(item);
        public void CopyTo(T[] array, int arrayIndex) => List.CopyTo(array, arrayIndex);
        public int IndexOf(T item) => List.IndexOf(item);

        public void Add(T item)
        {
            this.ThrowIfFrozen();
            List.Add(item);
        }

        public void Insert(int index, T item)
        {
            this.ThrowIfFrozen();
            List.Insert(index, item);
        }

        public bool Remove(T item)
        {
            this.ThrowIfFrozen();
            return List.Remove(item);
        }

        public void RemoveAt(int index)
        {
            this.ThrowIfFrozen();
            List.RemoveAt(index);
        }

        public void Clear()
        {
            this.ThrowIfFrozen();
            List.Clear();
        }

        // IFrozen-related

        public override void Freeze()
        {
            base.Freeze();
            if (!AreItemsFrozen)
                return;
            foreach (var item in List)
                if (item is IFrozen f)
                    f.Freeze();
        }

        public override IFrozen BaseToUnfrozen(bool deep = false)
        {
            var clone = (FrozenList<T>) base.BaseToUnfrozen(deep);
            if (!deep || !AreItemsFrozen) {
                clone.List = new List<T>(List);
                return clone;
            }

            var list = new List<T>(Count);
            foreach (var item in List) {
                if (item is IFrozen f)
                    list.Add((T) f.ToUnfrozen(deep));
                else
                    list.Add(item);
            }
            clone.List = list;
            return clone;
        }
    }
}