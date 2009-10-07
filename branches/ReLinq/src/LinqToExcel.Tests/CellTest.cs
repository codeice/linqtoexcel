﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;

namespace LinqToExcel.Tests
{
    [Author("Paul Yoder", "paulyoder@gmail.com")]
    [TestCategory("Unit")]
    [TestFixture]
    public class CellTest
    {
        [Test]
        public void Cell_implicitly_converts_to_string()
        {
            var newCell = new Cell("some value");
            Assert.IsTrue("some value" == newCell);
        }

        [Test]
        public void Constructor_sets_cell_value()
        {
            var newCell = new Cell("hello");
            Assert.AreEqual("hello", newCell.Value);
        }

        [Test]
        public void As_converts_cell_value_type_to_generic_argument_type()
        {
            var newCell = new Cell("2");
            Assert.AreEqual(2, newCell.As<int>());
            Assert.AreEqual(typeof(int), newCell.As<int>().GetType());
        }

        [Test]
        public void As_returns_default_generic_value_when_value_is_null()
        {
            var newCell = new Cell(null);
            Assert.AreEqual(0, newCell.As<int>());
        }

        [Test]
        public void ValueAs_returns_default_generic_value_when_value_is_DBNull()
        {
            var newCell = new Cell(DBNull.Value);
            Assert.AreEqual(0, newCell.As<int>());
        }

        [Test]
        public void to_string_returns_value_as_string()
        {
            var newCell = new Cell("hello");
            Assert.AreEqual("hello", newCell.ToString());
        }
    }
}
