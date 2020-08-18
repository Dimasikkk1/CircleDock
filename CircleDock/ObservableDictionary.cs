using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace CircleDock
{
    class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, INotifyCollectionChanged where TValue : class
    {
        private readonly IDictionary<TKey, TValue> pairs;

        public TValue this[TKey key]
        {
            get => pairs.ContainsKey(key) ? pairs[key] : null;
            set
            {
                pairs[key] = value;

                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, key, key, 0));
            }
        }
        public ICollection<TKey> Keys => pairs.Keys;
        public ICollection<TValue> Values => pairs.Values;
        public int Count => pairs.Count;
        public bool IsReadOnly => pairs.IsReadOnly;

        public ObservableDictionary() => pairs = new Dictionary<TKey, TValue>();
        public ObservableDictionary(int capacity) => pairs = new Dictionary<TKey, TValue>(capacity);
        public ObservableDictionary(IEqualityComparer<TKey> comparer) => pairs = new Dictionary<TKey, TValue>(comparer);
        public ObservableDictionary(IDictionary<TKey, TValue> dictionary) => pairs = new Dictionary<TKey, TValue>(dictionary);
        public ObservableDictionary(int capacity, IEqualityComparer<TKey> comparer) => pairs = new Dictionary<TKey, TValue>(capacity, comparer);
        public ObservableDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer) => pairs = new Dictionary<TKey, TValue>(dictionary, comparer);

        public void UpdateKey(TKey key) => OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, key, key, 0));
        public void Add(TKey key, TValue value)
        {
            if (pairs.ContainsKey(key))
                return;

            pairs.Add(key, value);

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, key, 0));
        }
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            if (pairs.ContainsKey(item.Key))
                return;

            pairs.Add(item);

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item.Key, 0));
        }
        public void Clear()
        {
            pairs.Clear();

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        public bool Contains(KeyValuePair<TKey, TValue> item) => pairs.Contains(item);
        public bool ContainsKey(TKey key) => pairs.ContainsKey(key);
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => pairs.CopyTo(array, arrayIndex);
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => pairs.GetEnumerator();
        public bool Remove(TKey key)
        {
            bool result = pairs.Remove(key);

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, key, 0));

            return result;
        }
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            bool result = pairs.Remove(item.Key);

            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item.Key, 0));

            return result;
        }
        public bool TryGetValue(TKey key, out TValue value) => pairs.TryGetValue(key, out value);
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)pairs).GetEnumerator();

        #region INotifyCollectionChanged
        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e) => CollectionChanged?.Invoke(this, e);
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        #endregion
    }
}
