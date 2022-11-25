using System;
using System.IO;
using Xunit;
using OrderBot;

namespace OrderBot.tests
{
    public class OrderBotTest
    {
        [Fact]
        public void Test1()
        {

        }
        [Fact]
        public void TestWelcome()
        {
            Session oSession = new Session("12345");
            String sInput = oSession.OnMessage("hello")[0];
            Assert.True(sInput.Contains("Welcome"));
        }
        [Fact]
        public void TestDental()
        {
            Session oSession = new Session("12345");
            String sInput = oSession.OnMessage("hello")[0];
            Assert.True(sInput.ToLower().Contains("Dental"));
        }
        [Fact]
        public void TestDate()
        {
            Session oSession = new Session("12345");
            String sInput = oSession.OnMessage("hello")[1];
            Assert.True(sInput.ToLower().Contains("date"));
        }
        [Fact]
        public void TestCleaning()
        {
            Session oSession = new Session("12345");
            oSession.OnMessage("hello");
            String sInput = oSession.OnMessage("cleaning")[0];
            Assert.True(sInput.ToLower().Contains("appointment"));
            
        }
        [Fact]
        public void TestChicken()
        {
            string sPath = DB.GetConnectionString();
            Session oSession = new Session("12345");
            oSession.OnMessage("hello");
            oSession.OnMessage("large");
            String sInput = oSession.OnMessage("chicken")[0];
            Assert.True(sInput.ToLower().Contains("toppings"));
            Assert.True(sInput.ToLower().Contains("large"));
            Assert.True(sInput.ToLower().Contains("chicken"));
        }
    }
}
