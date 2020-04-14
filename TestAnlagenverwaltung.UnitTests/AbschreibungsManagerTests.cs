using System;
using System.Net.Http;
using Anlagenverwaltung;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class AbschreibungsManagerTests

    {
        private AbschreibungsManager _abschreibungsManager;

        [SetUp]
        public void Setup()
        {
            _abschreibungsManager = new AbschreibungsManager();
        }

        [Test]
        public void BerechneAfaProzent_WhenCalled_ReturnNutzungsdauerInProzent()
        {
            var result = _abschreibungsManager.BerechneAfaProzent(1);

            Assert.That(result, Is.EqualTo(100));
        }

        [Test]
        public void BerechneAfaProzent_ParameterIsZero_ReturnsZero()
        {
            var result = _abschreibungsManager.BerechneAfaProzent(0);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void BerechneAbschreibungssatzJahr_WhenCalled_ReturnsAbschreibungssatzProJahr()
        {
            var result = _abschreibungsManager.BerechneAbschreibungssatzJahr(100, 1);

            Assert.That(result, Is.EqualTo(100));
        }

        [Test]
        public void BerechneAbschreibungssatzJahr_ParameterNutzungsdauerIsZero_ReturnsZero()
        {
            var result = _abschreibungsManager.BerechneAbschreibungssatzJahr(100, 0);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        [TestCase("2019-01-01", "2020-01-01", 1, 100, 0)]
        [TestCase("2019-01-01", "2019-01-01", 1, 100, 100)]
        [TestCase("2019-01-01", "2018-01-01", 1, 100, 100)]
        public void BerechneBuchwert_WhenCalled_ReturnsBuchWert(string vonDatum, string bisDatum, int nutzungsdauer, float anschaffungskosten, float expectedResult)
        {
            var result =
                _abschreibungsManager
                    .BerechneBuchwert(DateTime.Parse(vonDatum), DateTime.Parse(bisDatum), nutzungsdauer, anschaffungskosten);

            Assert.That(Math.Round(result), Is.EqualTo(expectedResult));
        }
    }
}