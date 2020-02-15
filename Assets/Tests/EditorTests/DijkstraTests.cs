using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class DijkstraTests : Dijkstra
    {

        [Test]
        public void ContainsFalseTest()
        {
            bool[] array = { true, true, true };

            Assert.AreEqual(false, ContainsFalse(array));

            bool[] arrayHasFalse = { true, false, true };

            Assert.AreEqual(true, ContainsFalse(arrayHasFalse));
        }

    }
}
