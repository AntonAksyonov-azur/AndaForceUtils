using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AndaForceExtensions.com.andaforce.arazect.callback
{
    public class ChainHelper
    {
        private Thread _baseThread;
        private bool _chainInProgress;
        private bool _operationInProgress;
        private List<AbstractCallbackChainElement> _chain;
        private List<AbstractCallbackChainElement> _currentElements;

        public bool Start()
        {
            _baseThread = Thread.CurrentThread;

            if (_chain.Count > 0)
            {
                _chainInProgress = true;
                ThreadPool.QueueUserWorkItem(Process);

                return true;
            }
            return false;
        }

        public void AddChainElement(AbstractCallbackChainElement element)
        {
            _chain.Add(element);
        }

        public void RemoveChainElement(AbstractCallbackChainElement element)
        {
            _chain.Remove(element);
        }

        public void RemoveByPosition(int position)
        {
            if (position < _chain.Count)
            {
                _chain.RemoveAt(position);
            }
        }

        public int GetChainLenght()
        {
            return _chain.Count;
        }

        private void Process(object state)
        {
            while (_chainInProgress)
            {
                if (!_operationInProgress)
                {
                    _operationInProgress = true;
                    AbstractCallbackChainElement element = _chain.FirstOrDefault(a => a.Status == ChainActionStatus.NotStarted);
                    if (element != null)
                    {
                        if (element.AllowParallel)
                        {
                            ConcurrentOperations(element);
                        }
                        else
                        {
                            // TODO Как-то запустить в базовом потоке...
                            int a = 1;
                        }
                       

                        element.PerformOperation();
                    }
                    
                }
            }
        }

        private void ConcurrentOperations(AbstractCallbackChainElement element)
        {
            _currentElements = _chain.Where(a => a.ParallelChainId == element.ParallelChainId).ToList();
            foreach (var ce in _currentElements)
            {
                ThreadPool.QueueUserWorkItem(delegate { ce.PerformOperation(); });
            }
        }
    }
}