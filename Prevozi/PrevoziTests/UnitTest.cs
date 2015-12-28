using System;
using Windows.UI.Xaml.Controls;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Prevozi.Models;

namespace PrevoziTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidateCarshareSearch()
        {
            TextBox txtOdhod = new TextBox();
            txtOdhod.Text = "Ljubljana";
            TextBox txtPrihod = new TextBox();
            txtPrihod.Text = "Maribor";
            DatePicker dpCasOdhoda = new DatePicker();

            Assert.Equals(Prevozi.MainPage.ValidateUserSearch(txtOdhod.Text, txtPrihod.Text), true);
        }
    }
}
