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
        public void GridGraphTestsSimplePasses()
        {
            width = 2;
            height = 2;
            MountGraph();


        }

    }
}
