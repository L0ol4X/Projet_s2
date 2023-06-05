using Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace TestsProject
{
    public class TestIngredient
    {
        [Fact]
        public void testEquals()
        {
            Ingredient i1 = new Ingredient("patate", 3, "");
            Ingredient i2 = new Ingredient("patate", 3, "");
            Assert.True(i1.Equals(i2));
        }

        
        
        [Fact]
        public void TestToString()
        {
            Ingredient i1 = new Ingredient("patate", 3, "");
            Ingredient i2 = new Ingredient("eau", 50, "cL");
            StringBuilder sb = new StringBuilder();
            sb.Append(i1.Qte.ToString() + ' ' + i1.Nom);
            Assert.Equal(sb.ToString(), i1.ToString());
            StringBuilder sb2 = new StringBuilder();
            sb2.Append(i2.Qte.ToString() + ' ' + i2.Nom);
            Assert.Equal(sb2.ToString(), i2.ToString());
        }

        [Fact]
        public void TestEqualsIngredient()
        {
            Ingredient i1 = new Ingredient("patates", 4, "");
            Ingredient i2 = new Ingredient("patates", 4, "");
            Assert.True(i1.Equals(i2));

            Ingredient i3 = new Ingredient("patates", 4, "");
            Ingredient? i4 = null;
            Assert.False(i3.Equals(i4));

            Ingredient i5 = new Ingredient("patates", 4, "");
            Ingredient i6 = new Ingredient("patates", 5, "");
            Assert.False(i5.Equals(i6));

            Assert.False(i3.Equals(new Quantite(4, "g")));
            Assert.False(i3.Equals(null));
        }

        [Fact]
        public void TestGetHashCode()
        {
            Ingredient i1 = new Ingredient("patates", 4, "");
            Assert.Equal(i1.Nom.GetHashCode(), i1.GetHashCode());
        }

    }
}
