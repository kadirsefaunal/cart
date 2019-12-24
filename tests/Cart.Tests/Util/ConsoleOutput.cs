using System;
using System.IO;

namespace Cart.Tests.Util
{
    /// <summary>
    /// Source of this class:
    /// https://www.codeproject.com/Articles/501610/Getting-Console-Output-Within-A-Unit-Test
    ///
    /// This class was used to test console output.
    /// </summary>
    public class ConsoleOutput : IDisposable
    {
        private StringWriter stringWriter;
        private TextWriter originalOutput;
 
        public ConsoleOutput()
        {
            stringWriter = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(stringWriter);
        }
 
        public string GetOuput()
        {
            return stringWriter.ToString();
        }
 
        public void Dispose()
        {
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }
    }
}