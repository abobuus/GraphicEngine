using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mathematics;
using Exceptions;
using static Exceptions.EngineException;

namespace GraphicEngine.Tests
{
    [TestClass]
    public class IdentifierTests
    {
        [TestMethod]
        public void Identifier_Generation()
        {
            bool flag = true;

            Identifier[] identifiers = new Identifier[10000];

            for (int i = 0; i < 10000; i++)
            {
                Identifier identifier = new Identifier();
                identifiers[i] = identifier;
            }

            for (int i = 0; i < 9999; i++)
                for (int j = i + 1; j < 10000; j++)
                    if (identifiers[i] == identifiers[j])
                        flag = false;

            Assert.IsTrue(flag);
        }
    }
}
