using Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsProject
{
    public class TestQuantite
    {
        [Fact]
        public void TestEqualsQuantite()
        {
            Quantite q1 = new Quantite(4, "g");
            Quantite q2 = new Quantite(4, "g");
            Assert.True(q1.Equals(q2));

            Quantite q3 = new Quantite(4, "g");
            Quantite q4 = new Quantite(5, "g");
            Assert.False(q3.Equals(q4));

            Quantite q5 = new Quantite(4, "g");
            Quantite? q6 = null;
            Assert.False(q5.Equals(q6));

            Assert.False(q3.Equals(new Ingredient("viande", 4, "g")));
            Assert.False(q3.Equals(null));
        }

        [Fact]
        public void TestGetHashCode()
        {
            Quantite q1 = new Quantite(4, "g");
            Assert.Equal(q1.Qtite.GetHashCode(), q1.GetHashCode());
        }
    }
}
