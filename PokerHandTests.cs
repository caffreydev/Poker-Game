namespace Poker.Tests;

using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

[TestFixture]
public class PokerTests
{
    [TestCase("Highest straight flush wins", EResult.Loss, "2H 3H 4H 5H 6H", "KS AS TS QS JS")]
    [TestCase("Straight flush wins of 4 of a kind", EResult.Win, "2H 3H 4H 5H 6H", "AS AD AC AH JD")]
    [TestCase("Highest 4 of a kind wins", EResult.Win, "AS AH 2H AD AC", "JS JD JC JH 3D")]
    [TestCase("4 of a kind with higher kicker wins", EResult.Win, "JC KH JS JD JH", "JC 7H JS JD JH")]
    [TestCase("4 Of a kind wins of full house", EResult.Loss, "2S AH 2H AS AC", "JS JD JC JH AD")]
    [TestCase("Full house wins of flush", EResult.Win,  "2S AH 2H AS AC", "2H 3H 5H 6H 7H")]
    [TestCase("Highest flush wins", EResult.Win, "AS 3S 4S 8S 2S", "2H 3H 5H 6H 7H")]
    [TestCase("Flush wins of straight", EResult.Win, "2H 3H 5H 6H 7H", "2S 3H 4H 5S 6C")]
    [TestCase("Equal straight is tie", EResult.Tie, "2S 3H 4H 5S 6C", "3D 4C 5H 6H 2S")]
    [TestCase("Straight wins of three of a kind", EResult.Win, "2S 3H 4H 5S 6C", "AH AC 5H 6H AS")]
    [TestCase("3 Of a kind wins of two pair", EResult.Loss, "2S 2H 4H 5S 4C", "AH AC 5H 6H AS")]
    [TestCase("2 Pair wins of pair", EResult.Win, "2S 2H 4H 5S 4C", "AH AC 5H 6H 7S")]
    [TestCase("Highest pair wins", EResult.Loss, "6S AD 7H 4S AS", "AH AC 5H 6H 7S")]
    [TestCase("Pair wins of nothing", EResult.Loss, "2S AH 4H 5S KC", "AH AC 5H 6H 7S")]
    [TestCase("Highest card loses", EResult.Loss, "2S 3H 6H 7S 9C", "7H 3C TH 6H 9S")]
    [TestCase("Highest card wins", EResult.Win, "4S 5H 6H TS AC", "3S 5H 6H TS AC")]
    [TestCase("Equal cards is tie",	EResult.Tie, "2S AH 4H 5S 6C", "AD 4C 5H 6H 2C")]
    public void PokerHandTest(string description, EResult expected, string hand, string opponentHand)
    {
        Assert.That(new PokerHand(hand).CompareWith(new PokerHand(opponentHand)), Is.EqualTo(expected), description);
    }
}