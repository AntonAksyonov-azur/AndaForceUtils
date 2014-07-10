using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AndaForceUtils.Collections.Generic
{
    public class CycledList<T> : IEnumerable<T>
    {
        public List<T> ListSource { get; private set; }
        public int CurrentPosition { get; private set; }

        public int Lenght
        {
            get { return ListSource.Count; }
        }

        #region Constructors

        public CycledList()
        {
            ListSource = new List<T>();
            CurrentPosition = -1;
        }

        public CycledList(IEnumerable<T> source)
        {
            ListSource = new List<T>(source);
            CurrentPosition = -1;
        }

        #endregion

        #region Public methods

        public void Add(T value)
        {
            ListSource.Add(value);
        }

        public T GetCurrent()
        {
            if (!ListSource.Any())
            {
                throw new IndexOutOfRangeException("No elements in CycledList presented");
            }

            if (CurrentPosition == -1)
            {
                CurrentPosition = 0;
            }

            return ListSource[CurrentPosition];
        }

        public T GetNext()
        {
            SwitchPosition(1);
            return GetCurrent();
        }

        public T GetPrev()
        {
            SwitchPosition(-1);
            return GetCurrent();
        }

        public void SwithPositionToEnd()
        {
            CurrentPosition = ListSource.Count - 1;
        }

        public void SwitchPositionToStart()
        {
            CurrentPosition = 0;
        }

        #endregion

        private void SwitchPosition(int direction)
        {
            CurrentPosition += direction;
            if (CurrentPosition < 0)
            {
                CurrentPosition = ListSource.Count - 1;
            }
            else
            {
                CurrentPosition = CurrentPosition % ListSource.Count;    
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ListSource.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}