using FluentAssertions;
using NUnit.Framework;
using System.Diagnostics;
using mIRE.World.Domain;

namespace mIRE.World.Tests
{
    public class DebugTests
    {
        [SetUp]
        public void Setup()
        {
            Debugger.Break();
        }

        [Test]
        public void NewCellTests()
        {
            var cell = new Cell();

            cell.Key.Should().BeEmpty();
        }
    }
}