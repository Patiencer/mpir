/*
Copyright 2014 Alex Dyachenko

This file is part of the MPIR Library.

The MPIR Library is free software; you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published
by the Free Software Foundation; either version 3 of the License, or (at
your option) any later version.

The MPIR Library is distributed in the hope that it will be useful, but
WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Lesser General Public
License for more details.

You should have received a copy of the GNU Lesser General Public License
along with the MPIR Library.  If not, see http://www.gnu.org/licenses/.  
*/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MPIR.Tests.HugeFloatTests
{
    [TestClass]
    public class Assignment
    {
        [TestInitialize]
        public void Setup()
        {
            HugeFloat.DefaultPrecision = 256;
        }

        [TestCleanup]
        public void Cleanup()
        {
            HugeFloat.DefaultPrecision = 64;
        }

        [TestMethod]
        public void FloatAssignCopy()
        {
            using (var a = new HugeFloat("-222509832503450298345029835740293845720.5"))
            using (var b = new HugeFloat())
            {
                b.Value = a;
                Assert.AreEqual("-0.2225098325034502983450298357402938457205@39", b.ToString());
            }
        }

        [TestMethod]
        public void FloatSwap()
        {
            using (var a = new HugeFloat("-222509832503450298345029835740293845720.5"))
            using (var b = new HugeFloat("2039847290878794872059384789347534534.75"))
            {
                var aValue = a._value();
                var bValue = b._value();
                a.Swap(b);
                Assert.AreEqual(bValue, a._value());
                Assert.AreEqual(aValue, b._value());
            }
        }

        [TestMethod]
        public void FloatCompoundOperators()
        {
            using (var a = new HugeFloat("938475092834705928347523452345.125"))
            {
                a.Value += 1;
                a.Value *= 10;
                Assert.AreEqual("0.938475092834705928347523452346125@31", a.ToString());
            }
        }

        [TestMethod]
        public void FloatAssignInt()
        {
            using (var a = new HugeInt("222509832503450298345029835740293845720"))
            using (var b = new HugeFloat("1234567"))
            {
                b.SetTo(a);
                Assert.AreEqual("0.22250983250345029834502983574029384572@39", b.ToString());
            }
        }

        //more tests coming here
    }
}
