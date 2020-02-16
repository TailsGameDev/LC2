using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GridGraphTests : GridGraph
    {
        [Test]
        public void AllNeighborhoods2x2Grid()
        {
            width = 2;
            height = 2;
            MountGraph();

            List<int> neighbors0 = GetNeighbors(0);
            Assert.Contains(1, neighbors0);
            Assert.Contains(2, neighbors0);
            Assert.AreEqual(neighbors0.Count, 2);

            List<int> neighbors1 = GetNeighbors(1);
            Assert.Contains(0, neighbors1);
            Assert.Contains(3, neighbors1);
            Assert.AreEqual(neighbors1.Count, 2);

            List<int> neighbors2 = GetNeighbors(2);
            Assert.Contains(0, neighbors2);
            Assert.Contains(3, neighbors2);
            Assert.AreEqual(neighbors2.Count, 2);

            List<int> neighbors3 = GetNeighbors(3);
            Assert.Contains(2, neighbors3);
            Assert.Contains(1, neighbors3);
            Assert.AreEqual(neighbors3.Count, 2);
        }

    }
}
