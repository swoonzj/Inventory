using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace Inventory
{
    class CustomerCollection : IEnumerable
    {
        public ArrayList customers { get; set; }

        #region IEnumerator Stuff

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)new CustomerCollectionEnumerator(this);
        }

        // For use with foreach
        private class CustomerCollectionEnumerator : IEnumerator
        {
            private CustomerCollection _customercollection;
            private int _index;

            public CustomerCollectionEnumerator(CustomerCollection customers)
            {
                _customercollection = customers;
                _index = -1;
            }

            public void Reset()
            {
                _index = -1;
            }

            public object Current
            {
                get
                {
                    return _customercollection.customers[_index];
                }
            }

            public bool MoveNext()
            {
                _index++;
                if (_index >= _customercollection.customers.Count)
                    return false;
                else
                    return true;
            }
        }
        #endregion

        public CustomerCollection()
        {
            customers = new ArrayList();
        }

        public int Count()
        {
            return customers.Count;
        }

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public void RemoveCustomer(Customer customer)
        {
            customers.Remove(customer);
        }
    }
}
