using System;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace Ada
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Controller ada = new Controller();
            ada.newCarteira();
        }
    }
}