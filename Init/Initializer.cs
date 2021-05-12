using Spreetail.MultiValueDictionary.Services.Interfaces.v1;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spreetail.MultiValueDictionary
{
    /// <summary>
    /// Initializer class 
    /// </summary>
    public class Initializer
    {
        private readonly IMultiValueDictionary<string,string> _multiValueDictionary;
        /// <summary>
        /// Constructor for injecting multiValueDictionary object
        /// </summary>
        public Initializer(IMultiValueDictionary<string,string> multiValueDictionary)
        {
            _multiValueDictionary = multiValueDictionary;
        }

        /// <summary>
        /// Logic starts from here
        /// </summary>
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
