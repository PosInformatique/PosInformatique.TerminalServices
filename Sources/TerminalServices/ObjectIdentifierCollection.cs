using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PosInformatique.TerminalServices
{
    public abstract class ObjectIdentifierCollection<T> : ReadOnlyCollection<T>
        where T : class, IObjectIdentifier
    {
        internal protected ObjectIdentifierCollection()
            : base(new List<T>())
        {

        }

        internal void Add(T obj)
        {
            this.Items.Add(obj);
        }
        internal void Clear()
        {
            this.Items.Clear();
        }

        public T Find(int id)
        {
            foreach (T session in this)
            {
                if (session.Id == id)
                    return session;
            }

            return null;
        }

        internal void RemoveAt(int i)
        {
            this.Items.RemoveAt(i);
        }
    }
}
