using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GaleShapley.Tests
{
    [TestClass()]
    public class GaleShapleyAlgorithmTests
    {
        GaleShapleyAlgorithm solver = new GaleShapleyAlgorithm();

        /// <summary>
        /// Simple test that would create new pairings due to an instability during the initial pairings.
        /// </summary>
        [TestMethod()]
        public void SimpleInstabilityTest()
        {
            var m1 = new Man("Johnny");
            var m2 = new Man("James");

            var w1 = new Woman("Jane");
            var w2 = new Woman("Joyce");

            m1.AddPersonToPrefList(w1);
            m1.AddPersonToPrefList(w2);

            m2.AddPersonToPrefList(w1);
            m2.AddPersonToPrefList(w2);

            w1.AddPersonToPrefList(m2);
            w1.AddPersonToPrefList(m1);

            w2.AddPersonToPrefList(m1);
            w2.AddPersonToPrefList(m2);

            List<IPerson> proposers = new List<IPerson>
            {
                m1,
                m2
            };

            List<IPerson> acceptees = new List<IPerson>
            {
                w1,
                w2
            };

            var result = solver.FindStableMatches(proposers, acceptees);

            Assert.AreEqual(result[m1], w2);
            Assert.AreEqual(result[m2], w1);
        }

        /// <summary>
        /// Simple test that does not result in an instability, which would change initial pairings.
        /// </summary>
        [TestMethod()]
        public void SimpleNoInstabilityTest()
        {
            var m1 = new Man("Johnny");
            var m2 = new Man("James");

            var w1 = new Woman("Jane");
            var w2 = new Woman("Joyce");

            m1.AddPersonToPrefList(w1);
            m1.AddPersonToPrefList(w2);

            m2.AddPersonToPrefList(w2);
            m2.AddPersonToPrefList(w1);

            w1.AddPersonToPrefList(m1);
            w1.AddPersonToPrefList(m2);

            w2.AddPersonToPrefList(m2);
            w2.AddPersonToPrefList(m1);

            List<IPerson> proposers = new List<IPerson>
            {
                m1,
                m2
            };

            List<IPerson> acceptees = new List<IPerson>
            {
                w1,
                w2
            };

            var result = solver.FindStableMatches(proposers, acceptees);

            Assert.AreEqual(result[m1], w1);
            Assert.AreEqual(result[m2], w2);
        }

        /// <summary>
        /// Inputs are empty for both proposers and acceptees
        /// </summary>
        [TestMethod()]
        public void EmptyInputTest()
        {
            List<IPerson> proposers = new List<IPerson>();
            List<IPerson> acceptees = new List<IPerson>();

            var result = solver.FindStableMatches(proposers, acceptees);

            Assert.IsNull(result);
        }

        /// <summary>
        /// Inputs are null for both proposers and acceptees
        /// </summary>
        [TestMethod()]
        public void NullInputTest()
        {
            List<IPerson> proposers = null;
            List<IPerson> acceptees = null;

            var result = solver.FindStableMatches(proposers, acceptees);

            Assert.IsNull(result);
        }

        /// <summary>
        /// Incorrect size for inputs between proposers and acceptees.
        /// </summary>
        [TestMethod()]
        public void WrongInputSizeTest()
        {
            var m1 = new Man("Johnny");
            var m2 = new Man("James");

            var w1 = new Woman("Jane");
            var w2 = new Woman("Joyce");

            m1.AddPersonToPrefList(w1);
            m1.AddPersonToPrefList(w2);

            m2.AddPersonToPrefList(w1);
            m2.AddPersonToPrefList(w2);

            w1.AddPersonToPrefList(m2);
            w1.AddPersonToPrefList(m1);

            w2.AddPersonToPrefList(m1);
            w2.AddPersonToPrefList(m2);

            List<IPerson> proposers = new List<IPerson>
            {
                m1
            };

            List<IPerson> acceptees = new List<IPerson>
            {
                w1,
                w2
            };

            var result = solver.FindStableMatches(proposers, acceptees);

            Assert.IsNull(result);
        }

        /// <summary>
        /// Complex test that would create new pairings due to an instability during the initial pairings.
        /// </summary>
        [TestMethod()]
        public void ComplexInstabilityTest()
        {
            var m1 = new Man("Johnny");
            var m2 = new Man("James");
            var m3 = new Man("Joe");

            var w1 = new Woman("Jane");
            var w2 = new Woman("Joyce");
            var w3 = new Woman("Jenny");

            m1.AddPersonToPrefList(w1);
            m1.AddPersonToPrefList(w3);
            m1.AddPersonToPrefList(w2);

            m2.AddPersonToPrefList(w1);
            m2.AddPersonToPrefList(w2);
            m2.AddPersonToPrefList(w3);

            m3.AddPersonToPrefList(w1);
            m3.AddPersonToPrefList(w2);
            m3.AddPersonToPrefList(w3);

            w1.AddPersonToPrefList(m1);
            w1.AddPersonToPrefList(m3);
            w1.AddPersonToPrefList(m2);

            w2.AddPersonToPrefList(m1);
            w2.AddPersonToPrefList(m3);
            w2.AddPersonToPrefList(m2);

            w3.AddPersonToPrefList(m1);
            w3.AddPersonToPrefList(m2);
            w3.AddPersonToPrefList(m3);

            List<IPerson> proposers = new List<IPerson>
            {
                m1,
                m2,
                m3
            };

            List<IPerson> acceptees = new List<IPerson>
            {
                w1,
                w2,
                w3
            };

            var result = solver.FindStableMatches(proposers, acceptees);

            Assert.AreEqual(result[m1], w1);
            Assert.AreEqual(result[m2], w3);
            Assert.AreEqual(result[m3], w2);
        }

        /// <summary>
        /// Complex test that would not result in instabilities during the initial pairings
        /// </summary>
        [TestMethod()]
        public void ComplexNoInstabilityTest()
        {
            var m1 = new Man("Johnny");
            var m2 = new Man("James");
            var m3 = new Man("Joe");

            var w1 = new Woman("Jane");
            var w2 = new Woman("Joyce");
            var w3 = new Woman("Jenny");

            m1.AddPersonToPrefList(w1);
            m1.AddPersonToPrefList(w3);
            m1.AddPersonToPrefList(w2);

            m2.AddPersonToPrefList(w1);
            m2.AddPersonToPrefList(w2);
            m2.AddPersonToPrefList(w3);

            m3.AddPersonToPrefList(w1);
            m3.AddPersonToPrefList(w2);
            m3.AddPersonToPrefList(w3);
      
            w1.AddPersonToPrefList(m1);
            w1.AddPersonToPrefList(m2);
            w1.AddPersonToPrefList(m3);

            w2.AddPersonToPrefList(m1);
            w2.AddPersonToPrefList(m2);
            w2.AddPersonToPrefList(m3);

            w3.AddPersonToPrefList(m1);
            w3.AddPersonToPrefList(m2);
            w3.AddPersonToPrefList(m3);

            List<IPerson> proposers = new List<IPerson>
            {
                m1,
                m2,
                m3
            };

            List<IPerson> acceptees = new List<IPerson>
            {
                w1,
                w2,
                w3
            };

            var result = solver.FindStableMatches(proposers, acceptees);

            Assert.AreEqual(result[m1], w1);
            Assert.AreEqual(result[m2], w2);
            Assert.AreEqual(result[m3], w3);
        }
    }
}