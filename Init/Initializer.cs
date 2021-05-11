using Spreetail.MultiValueDictionary.Services.Interfaces.v1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spreetail.MultiValueDictionary
{
    public class Initializer
    {
        private readonly IMultiValueDictionary<string,string> _multiValueDictionary;
        public Initializer(IMultiValueDictionary<string,string> multiValueDictionary)
        {
            _multiValueDictionary = multiValueDictionary;
        }

        public void Run()
        {
            Util.Util.ShowOperationList();

            do
            {
                string operation = Console.ReadLine();

                if (operation.ToUpper().Equals("EXIT"))
                {
                    Environment.Exit(0);
                }

                Util.Util.CallOperation(operation, _multiValueDictionary);
                Console.Write("\n");

            } while (true);
        }
    }
}
